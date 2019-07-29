import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import * as $ from 'jquery';
import * as toastr from 'toastr';

@Component({
  selector: 'app-cardapio',
  templateUrl: './cardapio.component.html',
  styleUrls: ['./cardapio.component.css']
})
export class CardapioComponent {
  [x: string]: any;
  private readonly initialColSpanIngredientes = 4;
  public listaLanches: Lanche[];
  public colspanIngredientes: number = this.initialColSpanIngredientes;
  private modoVenda: boolean = false;
  private httpClient: HttpClient;
  private baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.httpClient = http;
    this.baseUrl = baseUrl;


    http.get<Lanche[]>(baseUrl + 'api/Cardapio/Lanches').subscribe(result => {
      this.listaLanches = result;
    }, error => console.error(error));
  }

  ativarModoVenda() {
    this.modoVenda = true;
    this.colspanIngredientes = this.initialColSpanIngredientes;
    $("#btnIniciarVenda").hide(200);
    $("#btnCancelarVenda").show(200);
    $("#btnFinalizarVenda").show(300);
  }

  cancelarModoVenda() {
    this.modoVenda = false;
    this.colspanIngredientes = this.initialColSpanIngredientes - 1;
    $("#btnIniciarVenda").show(200);
    $("#btnCancelarVenda").hide(200);
    $("#btnFinalizarVenda").hide(200);
  }

  finalizarVenda() {
    let selecionado = $("input:checked").parent().parent();
    if (selecionado.length <= 0) {
      toastr.warning("Nenhum lanche selecionado!");
    }
    let lancheCodigo = selecionado.find(".lanche-codigo").html()
    let ingredientesCodigo = "";
    selecionado.next().find(".ingrediente-codigo").each((index, elem) => {
      ingredientesCodigo += `${$(elem).html()},`;
    });

    ingredientesCodigo = ingredientesCodigo.substr(0, ingredientesCodigo.length - 1);

    let request = {
      CodigoLanche: parseInt(lancheCodigo),
      CodigoIngredientes: ingredientesCodigo.split(",").map(item => { return parseInt(item, 10); })
    };
    console.log(request);

    this.httpClient.post(this.baseUrl + 'api/Cardapio/FinalizarVenda', request, {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
      }).subscribe(result => {

    }, error => console.error(error));
  }

  isModoVenda() {
    return this.modoVenda;
  }
}

interface Lanche {
  codigo: number;
  nome: string;
  ingredientes: Ingrediente[];
}

interface Ingrediente {
  codigo: number;
  nome: string;
  preco: number;
}
