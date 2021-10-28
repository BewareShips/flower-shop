using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DataContext _context;

        public OrderController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Order
        [HttpGet]
        public System.Object GetOrders()
        {
            var result = (from a in _context.Orders
                          join b in _context.Customers on a.CustomerID equals b.CustomerID

                          select new
                          {
                              a.OrderID,
                              a.OrderNo,
                              Customer = b.Name,
                              a.PMethod,
                              a.GTotal
                          }).ToList();

            return result;
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(long id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Order/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(long id, Order order)
        {
            if (id != order.OrderID)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Order
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            try
            {
                if (order.OrderID == 0)
                {
                    _context.Add(order);
                }
                else
                {
                    _context.Entry(order).State = EntityState.Modified;
                }

                

                foreach (var item in order.OrdersItems)
                {
                    if(item.OrderItemID == 0)
                    {
                        _context.OrderItems.Add(item);
                    }
                    else
                    {
                        _context.Entry(item).State = EntityState.Modified;
                    }
                }

                _context.SaveChanges();

                return Ok();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.OrderID }, order);
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(long id)
        {
            Order order = _context.Orders.Include(y => y.OrdersItems)
                .SingleOrDefault(x => x.OrderID == id);

            if(order.OrdersItems.Count != 0)
            {
                foreach (var item in order.OrdersItems.ToList())
                {
                    _context.OrderItems.Remove(item);
                }
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return Ok(order);
        }





        private bool OrderExists(long id)
        {
            return _context.Orders.Any(e => e.OrderID == id);
        }
    }
}
