import { Component, OnInit } from '@angular/core';
import { ApiclienteService } from '../services/apicliente.service';

import { DialogClienteComponent } from './dialog/dialogcliente.component';
import { MatDialog } from '@angular/material/dialog';
import { Cliente } from '../models/cliente';
import { DialogDeleteComponent } from '../common/delete/dialogdelete.component';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.scss']
})
export class ClienteComponent implements OnInit {
  public lst: any[] = [];
  public columnas: string[] = ['cliId', 'cliNombre','actions'];
  readonly width: string = '300px';
//Injectamos el servicio
  constructor(
    private apiCliente: ApiclienteService,
    public dialog: MatDialog,
    public snackBar: MatSnackBar,
  ) {
  
   }
  getClientes(){
    this.apiCliente.getClientes().subscribe(response =>{
      this.lst = response.data;
  }) // Siempre q llamamos al observable usamos subscribe
}
  openAdd(){
    const dialogRef = this.dialog.open(DialogClienteComponent, {
      width: this.width
    })
    dialogRef.afterClosed().subscribe(result =>{
      this.getClientes();
    })
  }

  openEdit(cliente: Cliente){
    const dialogRef = this.dialog.open(DialogClienteComponent, {
      data: cliente,
      width: this.width
      
    })
    dialogRef.afterClosed().subscribe(result =>{
      this.getClientes();
    })
  }

  Delete(cliente:Cliente){
    const dialogRef = this.dialog.open(DialogDeleteComponent, {
      width: this.width
    });
    dialogRef.afterClosed().subscribe(result => {
      if(result){
        this.apiCliente.delete(cliente.cliId).subscribe(response => {
          if(response.exito === 1){
            
            this.snackBar.open('Cliente eliminado con exito', '',{
              duration: 2000
            });
            
            this.getClientes();
          }
          
        });
      }
    });
  }
  ngOnInit(): void {
    this.getClientes();
  }

}
