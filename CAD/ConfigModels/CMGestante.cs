using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //Para implementar herencia de ValidationAttribute
using System.Linq;
using System.Threading.Tasks;
using ApiPersonalSalud.CEN.CenEntidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPersonalSalud.CAD.ConfigModels;
//Extraemos toda la configuracion de la Clase Gestante para reducir Tamaño en ModelCreating
public class CMGestante : IEntityTypeConfiguration<CENGestante>
{
    public void Configure(EntityTypeBuilder<CENGestante> builder)
    {
        //cONFIGURACION
            //**Configuracion del nombre de mi tabla
        builder.ToTable("Gestantes");
        builder.HasKey(g => g.Id);
            //**Configuracion para el campo Nombre
        builder.Property(g => g.Nombres)
                .IsRequired() //NOT NULL
                .HasMaxLength(150); //LONGITUD MAXIMA DE CARACTERES
        builder.Property(g => g.Apellidos)
                .IsRequired()
                .HasMaxLength(150);
                
            //**Configuracion de DNI: Solo nuemricos
        builder.Property(g=>g.DNI)
                .IsRequired()
                .HasMaxLength(8);

        builder.Property(g=>g.FechaNacimiento)
                .IsRequired(); //NOT NULL

            //**Añadimos una restriccion a nivel de entidad pero con el metodo toTable
        builder.ToTable(t=>{
            //Fecha de Nacimiento
            t.HasCheckConstraint(
                "CHK_CENGestante_FechaNacimiento",
                "FechaNacimiento <= DATEADD(YEAR,-14,GETDATE())");

                //TElefono
                 t.HasCheckConstraint(
                "CHK_CENGestante_Telefono",
                "Telefono IS NOT NULL OR (LEN(Telefono) = 9 AND Telefono NOT LIKE '%[^0-9]%')");

                //Correo
                t.HasCheckConstraint(
                "CHK_CENGestante_Correo",
                "Correo LIKE '_%@_%._%'");

                //Grupo Sangiuinero
                t.HasCheckConstraint(
                    "CHK_CENGestante_GrupoSanguineo",
                    "GrupoSanguineo BETWEEN 0 AND 7");
        });

            //**Configuracion de Direccion
        builder.Property(g=>g.Direccion)
                .IsRequired(false);
        builder.Property(g=>g.Telefono)
                .IsRequired()
                .HasMaxLength(9); //123456789
       
            //**Configuracion para la Edad Gestacional
        builder.Property(g=>g.EdadGestacional)
                .IsRequired();


        //CONFIGURACION DE RELACION
        builder.HasMany(g=>g.Citas) //Una gestante tiene muchas citas
                .WithOne(c=>c.Gestante) //Cada cida tiene una sola gestante
                .HasForeignKey(c=>c.IdGestante)
                .OnDelete(DeleteBehavior.Cascade);

        //CONFIGURACION DE RELACION DE UNO A UNO
        builder.HasOne(g=>g.Usuario)
                .WithOne(u=>u.Gestante)
                .HasForeignKey<CENUsuario>(u=>u.IdGestante)
                .OnDelete(DeleteBehavior.Cascade);

    }

    //VALIDACION PERSONALIZADA DE LA FECHA USANDO DATA ANNOTAIONS
    public class ValidarFechaNacimientoAttribute:ValidationAttribute{
        //Sobreescribimos el metodo
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //TECNICA FUNCIONAL-> uTILIZADA EN CONTROLES DE FLUJO
            //PATRON DE DECLARACION->Evalua una expresion si es un T.Dato y lo almacena en una nueva variable
            if(value is DateTime fechaNacimiento){
                //Establecemos una fecha Limite
                DateTime fechaLimite=DateTime.Now.AddYears(-14);
                if(fechaNacimiento>=fechaLimite)
                    return new ValidationResult($"La fecha de nacimiento tiene que ser menor a la fecha {fechaLimite}");
            }
            return ValidationResult.Success;
        }
    }

}
