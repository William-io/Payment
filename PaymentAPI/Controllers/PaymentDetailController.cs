using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.Models;
using PaymentAPI.Repository;
//unit of work
namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {
        private readonly IUnit _uow;

        public PaymentDetailController(IUnit context)
        {
            _uow = context;
        }

        // GET: api/PaymentDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetail>>> GetpaymentDetails()
        {
            return await _uow.PaymentDetailRepository.Get().ToListAsync();
        }

        // GET: api/PaymentDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetail>> GetPaymentDetail(int id)
        {
            var paymentDetail = await _uow.PaymentDetailRepository.GetById(p => p.PaymentDetailId == id);

            if (paymentDetail == null)
            {
                return NotFound();
            }

            return paymentDetail;
        }

        // PUT: api/PaymentDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentDetail(int id, PaymentDetail paymentDetail)
        {
            if (id != paymentDetail.PaymentDetailId)
            {
                return BadRequest();
            }

            _uow.PaymentDetailRepository.Update(paymentDetail);
            await _uow.Commit();
            // return Ok();

            try
            {
                await _uow.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentDetailExists(id))
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

        // POST: api/PaymentDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentDetail>> PostPaymentDetail(PaymentDetail paymentDetail)
        {
            _uow.PaymentDetailRepository.Add(paymentDetail);
            await _uow.Commit(); //SaveChanges

            return CreatedAtAction("GetPaymentDetail", new { id = paymentDetail.PaymentDetailId }, paymentDetail);
        }

        // DELETE: api/PaymentDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentDetail(int id)
        {
            var paymentDetail = await _uow.PaymentDetailRepository.GetById(p => p.PaymentDetailId == id);

            if (paymentDetail == null)
            {
                return NotFound();
            }

            _uow.PaymentDetailRepository.Delete(paymentDetail);
            await _uow.Commit();

            return NoContent();
        }

        private bool PaymentDetailExists(int id)
        {
            return _uow.PaymentDetailRepository.GetById(p => p.PaymentDetailId == id) != null;
        }
    }
}
