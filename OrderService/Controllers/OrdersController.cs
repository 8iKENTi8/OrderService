using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using OrderService.Models;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Инициализирует контекст базы данных через инъекцию зависимостей
        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/Orders
        // Метод для создания нового заказа
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            // Проверка на корректность входных данных
            if (order == null)
            {
                return BadRequest("Order object is null."); 
            }

            // Проверка на соответствие модели данных
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            order.updatedDate = DateTime.UtcNow; 

            _context.Orders.Add(order); 

            try
            {
                await _context.SaveChangesAsync(); 
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); 
            }

            // Возвращаем 201 Created с созданным заказом и ссылкой на метод получения заказа
            return CreatedAtAction(nameof(GetOrder), new { id = order.id }, order);
        }

        // GET: api/Orders/{id}
        // Метод для получения заказа по ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id); // Ищем заказ в базе данных по ID

            if (order == null)
            {
                return NotFound(); 
            }

            return order; 
        }

        // GET: api/Orders
        // Метод для получения списка всех заказов
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Orders.ToListAsync(); 
        }

        // DELETE: api/Orders/{id}
        // Метод для удаления заказа по ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id); 

            if (order == null)
            {
                return NotFound(); 
            }

            _context.Orders.Remove(order); 

            try
            {
                await _context.SaveChangesAsync(); 
            }
            catch (DbUpdateException ex)
            {
                // Ловим ошибку обновления базы данных и выводим сообщение
                return StatusCode(500, $"Internal server error: {ex.Message}"); 
            }

            return NoContent(); 
        }

        // GET: api/Orders/executors
        // Метод для получения списка всех исполнителей
        [HttpGet("executors")]
        public async Task<ActionResult<IEnumerable<Executor>>> GetExecutors()
        {
            return await _context.Executors.ToListAsync(); 
        }

        // PUT: api/Orders/{id}
        // Метод для обновления существующего заказа по ID
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            // Проверка на корректность входных данных
            if (id != order.id)
            {
                return BadRequest("Order ID mismatch."); 
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            var existingOrder = await _context.Orders.FindAsync(id); // Ищем существующий заказ в базе данных по ID
            if (existingOrder == null)
            {
                return NotFound(); 
            }

            // Обновление полей заказа
            existingOrder.status = order.status;
            existingOrder.description = order.description;
            existingOrder.pickupAddress = order.pickupAddress;
            existingOrder.deliveryAddress = order.deliveryAddress;
            existingOrder.comment = order.comment;
            existingOrder.executor = order.executor;
            existingOrder.width = order.width;
            existingOrder.height = order.height;
            existingOrder.depth = order.depth;
            existingOrder.weight = order.weight;
            existingOrder.updatedDate = DateTime.UtcNow; 

            try
            {
                await _context.SaveChangesAsync(); 
            }
            catch (DbUpdateConcurrencyException)
            {
                // Добавляем обработку исключения для случая, когда в базе данных изменена запись
                if (!OrderExists(id))
                {
                    return NotFound(); 
                }
                else
                {
                    return StatusCode(409, "Conflict: The order has been updated or deleted by another user."); 
                }
            }
            catch (DbUpdateException ex)
            {
                // Ловим ошибку обновления базы данных и выводим сообщение
                return StatusCode(500, $"Internal server error: {ex.Message}"); 
            }

            return NoContent(); 
        }

        // Проверка существования заказа по ID
        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.id == id); 
        }
    }
}
