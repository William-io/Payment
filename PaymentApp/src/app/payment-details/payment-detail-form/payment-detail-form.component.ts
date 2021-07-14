import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { PaymentDetail } from 'src/app/shared/payment-detail.model';
import { PaymentDetailService } from 'src/app/shared/payment-detail.service';

@Component({
  selector: 'app-payment-detail-form',
  templateUrl: './payment-detail-form.component.html',
  styles: [
  ]
})
export class PaymentDetailFormComponent implements OnInit {

  constructor(public service: PaymentDetailService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {
    if (this.service.formData.paymentDetailId == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);

    // this.service.postPaymentDetail().subscribe(
    //   res => {
    //     this.resetForm(form);
    //     this.toastr.success('Sucesso, Cartão adicionado!', 'Detalhe do Registro');
    //   },
    //   err => { console.log(err) }
    // );
  }

  insertRecord(form: NgForm) {
    this.service.postPaymentDetail().subscribe(
      res => {
        this.resetForm(form);
        this.toastr.success('Submetido com sucesso!', 'Detalhe do Registro');
      },
      err => { console.log(err); }
    );
  }

  updateRecord(form: NgForm) {
    this.service.putPaymentDetail().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.info('Atualizado com sucesso!', 'Detalhe do Registro');
      },
      err => { console.log(err); }
    );
  }
  
  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new PaymentDetail();
  }

}
