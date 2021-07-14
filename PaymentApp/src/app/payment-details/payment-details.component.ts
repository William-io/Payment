import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { PaymentDetail } from '../shared/payment-detail.model';
import { PaymentDetailService } from '../shared/payment-detail.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-payment-details',
  templateUrl: './payment-details.component.html',
  styles: [
  ]
})

export class PaymentDetailsComponent implements OnInit {

  //Injeta a classe serviço
  constructor(public service: PaymentDetailService,
    private toastr: ToastrService) { }

  //função para startar a lista
  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord: PaymentDetail) {
    this.service.formData = Object.assign({}, selectedRecord);
  }

  // onDelete(id: number) {
  //   if (confirm('Tem certeza que deseja deletar este registro?')) {
  //     this.service.deletePaymentDetail(id)
  //       .subscribe(
  //         res => {
  //           this.service.refreshList();
  //           this.toastr.error("Deletado com sucesso!", 'Detalhe do Registro');
  //         },
  //         err => { console.log(err) }
  //       )
  //   }
  // }

  onDelete(id: number){
    Swal.fire({
      title: 'Tem certeza?',
      text: 'Você não poderá recuperar este arquivo!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Sim, exclua!',
      cancelButtonText: 'Não, exclua!'
    }).then((result) => {
      if (result.isConfirmed) {
        this.service.deletePaymentDetail(id)
        .subscribe(
          res => {
            this.service.refreshList();
          }
        )
        Swal.fire(
          'Deletado',
          'Seu registro foi excluido!',
          'success'
        )
      // For more information about handling dismissals please visit
      // https://sweetalert2.github.io/#handling-dismissals
      } else if (result.dismiss === Swal.DismissReason.cancel) {
        Swal.fire(
          'Cancelado',
          'Seu registro continua seguro! :)',
          'error'
        )
      }
    })
  }

}
