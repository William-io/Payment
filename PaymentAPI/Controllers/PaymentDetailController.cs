using System.Collections.Generic;
using System.Linq;
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
        public ActionResult<IEnumerable<PaymentDetail>> GetpaymentDetails()
        {
            return _uow.PaymentDetailRepository.Get().ToList();
        }

        // GET: api/PaymentDetail/5
        [HttpGet("{id}")]
        public ActionResult<PaymentDetail> GetPaymentDetail(int id)
        {
            var paymentDetail = _uow.PaymentDetailRepository.GetById(p => p.PaymentDetailId == id);

            if (paymentDetail == null)
            {
                return NotFound();
            }

            return paymentDetail;
        }

        // PUT: api/PaymentDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutPaymentDetail(int id, PaymentDetail paymentDetail)
        {
            if (id != paymentDetail.PaymentDetailId)
            {
                return BadRequest();
            }

            _uow.PaymentDetailRepository.Update(paymentDetail);
            _uow.Commit();
            // return Ok();

            try
            {
                _uow.Commit();
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

            return Ok();
        }

        // POST: api/PaymentDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<PaymentDetail> PostPaymentDetail(PaymentDetail paymentDetail)
        {
            _uow.PaymentDetailRepository.Add(paymentDetail);
            _uow.Commit();

            return CreatedAtAction("GetPaymentDetail", new { id = paymentDetail.PaymentDetailId }, paymentDetail);
        }

        // DELETE: api/PaymentDetail/5
        [HttpDelete("{id}")]
        public IActionResult DeletePaymentDetail(int id)
        {
            var paymentDetail = _uow.PaymentDetailRepository.GetById(p => p.PaymentDetailId == id);
            if (paymentDetail == null)
            {
                return NotFound();
            }

            _uow.PaymentDetailRepository.Delete(paymentDetail);
            _uow.Commit();

            return NoContent();
        }

        private bool PaymentDetailExists(int id)
        {
            return _uow.PaymentDetailRepository.GetById(p => p.PaymentDetailId == id) != null;
        }
    }
}
