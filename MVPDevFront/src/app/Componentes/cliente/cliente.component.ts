import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Cliente } from 'src/app/Models/Cliente';
import { ClientesService } from 'src/app/clientes.service';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.css'],
})
export class ClienteComponent implements OnInit {
  formCliente: any;
  formTitle: string;
  listaClientes: Cliente[];
  hiddenTable: boolean = true;
  hiddenForm: boolean = false;
  clienteId: number;
  clienteCnpj: string;
  clienteNome: string;
  modalRef: BsModalRef;

  constructor(
    private clientesService: ClientesService,
    private modalService: BsModalService
    ) { }

  ngOnInit():void {
    this.clientesService.ListarClientes().subscribe(resultado => {
      this.listaClientes = resultado;
      });
  }

  ExibirFormCadastro(): void {
    this.hiddenTable = false;
    this.hiddenForm = true;
    this.formTitle = "Novo Cliente";
    this.formCliente = new FormGroup({
      cnpj: new FormControl(null),
      nome: new FormControl(null),
      razaoSocial: new FormControl(null),
      logradouro: new FormControl(null),
      logNumero: new FormControl(null),
      complemento: new FormControl(null),
      cep: new FormControl(null),
      bairro: new FormControl(null),
      municipio: new FormControl(null),
      cnae: new FormControl(null)
    });
  }

  ExibirFormAtualizacao(clienteId: number): void {
    this.hiddenTable = false;
    this.hiddenForm = true;
    this.clientesService.BuscarCliente(clienteId).subscribe(resultado => {
      this.formTitle = `Atualizar Cliente - ${resultado.cnpj} - ${resultado.nome}`;
      this.formCliente = new FormGroup({
        id: new FormControl(resultado.id),
        cnpj: new FormControl(resultado.cnpj),
        nome: new FormControl(resultado.nome),
        razaoSocial: new FormControl(resultado.razaoSocial),
        logradouro: new FormControl(resultado.logradouro),
        logNumero: new FormControl(resultado.logNumero),
        complemento: new FormControl(resultado.complemento),
        cep: new FormControl(resultado.cep),
        bairro: new FormControl(resultado.bairro),
        municipio: new FormControl(resultado.municipio),
        cnae: new FormControl(resultado.cnae)
      })
    });
  }

  VoltarFormCadastro(): void {
    this.hiddenTable = true;
    this.hiddenForm = false;
  }

  ConfirmaExclusaoCliente(clienteId: number, clienteCnpj: string, clienteNome: string, modalConteudo: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(modalConteudo);
    this.clienteId = clienteId;
    this.clienteCnpj = clienteCnpj;
    this.clienteNome = clienteNome;
  }

  ExcluirCliente(clienteId: number) {
    this.clientesService.ExcluirCliente(clienteId).subscribe(resultado => {
      this.modalRef.hide();
      alert('Cliente excluído com sucesso!');
      this.clientesService.ListarClientes().subscribe(registros => {
        this.listaClientes = registros;
        });
    });
  }

  EnviarFormulario(): void {
    const cliente : Cliente = this.formCliente.value;
    if (cliente.id > 0) {
      this.clientesService.AtualizarCliente(cliente.id, cliente).subscribe(resultado => {
        this.hiddenTable = true;
        this.hiddenForm = false;
        alert("Cliente atualizado com sucesso!");
        this.clientesService.ListarClientes().subscribe(registros => {
          this.listaClientes = registros;
        });
      });
    }
    else {
      this.clientesService.AdicionarCliente(cliente).subscribe(resultado => {
        this.hiddenTable = true;
        this.hiddenForm = false;
        alert("Cliente cadastrado com sucesso!");
        this.clientesService.ListarClientes().subscribe(registros => {
          this.listaClientes = registros;
        });
      });
    }
  }
}
