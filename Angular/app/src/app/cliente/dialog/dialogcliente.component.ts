import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Cliente } from 'src/app/models/cliente';
import { ApiclienteService } from 'src/app/services/apicliente.service';


@Component({
    templateUrl: 'dialogCliente.component.html'
})

export class DialogClienteComponent{

    public cliNombre: string = "test";
    public cliId: number = 0;

    constructor(
        public dialogRef: MatDialogRef<DialogClienteComponent>,
        public apiCliente: ApiclienteService,
        public snackBar: MatSnackBar,
        @Inject(MAT_DIALOG_DATA) public cliente: Cliente
    )
    {
        
            console.log(cliente);
            this.cliNombre = cliente.cliNombre;
        
    }

    close(){
        this.dialogRef.close();
    }

    editCliente(){
        const cliente: Cliente = { cliId: this.cliente.cliId, cliNombre: this.cliNombre};
        
        this.apiCliente.edit(cliente).subscribe(response =>{
            if(response.exito === 1)
            this.dialogRef.close();
            this.snackBar.open('Cliente Editado con exito','',{
                duration: 2000
            });
        })

    }
    addCliente(){
        const cliente: Cliente = { cliId: 0, cliNombre: this.cliNombre}
        console.log(cliente);
        this.apiCliente.add(cliente).subscribe(response =>{
            if(response.exito === 1)
            this.dialogRef.close();
            this.snackBar.open('Cliente insertado con exito','',{
                duration: 2000
            });
        })
    }
    
}