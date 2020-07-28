﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdventureOrderApp.Data;

namespace AdventureOrderApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderDetailsController : ControllerBase
    {
        private readonly AdventureWorksContext _context;

        public SalesOrderDetailsController(AdventureWorksContext context)
        {
            _context = context;
        }

        // GET: api/SalesOrderDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesOrderDetail>>> GetSalesOrderDetail()
        {
            return await _context.SalesOrderDetail.ToListAsync();
        }

        // GET: api/SalesOrderDetails/5
        [HttpGet("{salesOrderId}")]
        public async Task<ActionResult<List<SalesOrderDetail>>> GetSalesOrderDetail(int salesOrderId)
        {
            var salesOrderDetail = await _context.SalesOrderDetail.Where(sod => sod.SalesOrderId == salesOrderId).ToListAsync();

            if (salesOrderDetail == null)
            {
                return NotFound();
            }

            return salesOrderDetail;
        }

        // GET: api/SalesOrderDetails/5
        [HttpGet("{salesOrderId}/{salesOrderDetailID}")]
        public async Task<ActionResult<SalesOrderDetail>> GetSalesOrderSingleDetail(int salesOrderId, int salesOrderDetailID)
        {
            var salesOrderDetail = await _context.SalesOrderDetail.FindAsync(salesOrderId, salesOrderDetailID);

            if (salesOrderDetail == null)
            {
                return NotFound();
            }

            return salesOrderDetail;
        }

        // PUT: api/SalesOrderDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesOrderDetail(int id, SalesOrderDetail salesOrderDetail)
        {
            if (id != salesOrderDetail.SalesOrderId)
            {
                return BadRequest();
            }

            _context.Entry(salesOrderDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesOrderDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SalesOrderDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SalesOrderDetail>> PostSalesOrderDetail(SalesOrderDetail salesOrderDetail)
        {
            _context.SalesOrderDetail.Add(salesOrderDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SalesOrderDetailExists(salesOrderDetail.SalesOrderId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSalesOrderDetail", new { id = salesOrderDetail.SalesOrderId }, salesOrderDetail);
        }

        // DELETE: api/SalesOrderDetails/5
        [HttpDelete("{salesOrderId}/{salesOrderDetailID}")]
        public async Task<ActionResult<SalesOrderDetail>> DeleteSalesOrderDetail(int salesOrderId, int salesOrderDetailID)
        {
            var salesOrderDetail = await _context.SalesOrderDetail.FindAsync(salesOrderId, salesOrderDetailID);
            if (salesOrderDetail == null)
            {
                return NotFound();
            }

            _context.SalesOrderDetail.Remove(salesOrderDetail);
            await _context.SaveChangesAsync();

            return salesOrderDetail;
        }

        private bool SalesOrderDetailExists(int id)
        {
            return _context.SalesOrderDetail.Any(e => e.SalesOrderId == id);
        }
    }
}
