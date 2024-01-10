<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FrmFuente.aspx.cs" Inherits="primeraEntrega.FrmFuente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
	<div class="container-xl">
	<div class="table-responsive">
		<div class="table-wrapper">
			<div class="table-title">
				<div class="row">
					<div class="col-sm-6">
						<h2 class="miEstilo">Gestion <b>Fuente</b></h2>
					</div>
					<div class="col-sm-6">
						<a href="#crudModal" class="btn btn-success" data-toggle="modal"><i class="material-icons">&#xE147;</i> <span>Gestión Fuente</span></a>						
					</div>
				</div>
			</div>
			<table class="table table-striped table-hover">
				<thead>
					<tr>
						<th>
							<span class="custom-checkbox">
								<input type="checkbox" id="selectAll">
								<label for="selectAll"></label>
							</span>
						</th>
						<th>ID</th>
						<th>Nombre</th>
						<th>Actions</th>
					
					</tr>
				</thead>
				<tbody>
					<%

                        for (int i = 0; i < arregloFuente.Length; i++)
                        {
					%>
					<tr>
						<td>
							<span class="custom-checkbox">
								<input type="checkbox" id="checkbox1" name="options[]" value="1">
								<label for="checkbox1"></label>
							</span>
						</td>
						<td><% Response.Write(arregloFuente[i].Id); %></td>
						<td><% Response.Write(arregloFuente[i].Nombre); %></td>
						<td>
							<a href="#" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></a>
						</td>
					</tr>
					<%
						} 
					%>
				</tbody>
			</table>
			<div class="clearfix">
				<div class="hint-text">Showing <b>5</b> out of <b>25</b> entries</div>
				<ul class="pagination">
					<li class="page-item disabled"><a href="#">Previous</a></li>
					<li class="page-item"><a href="#" class="page-link">1</a></li>
					<li class="page-item"><a href="#" class="page-link">2</a></li>
					<li class="page-item active"><a href="#" class="page-link">3</a></li>
					<li class="page-item"><a href="#" class="page-link">4</a></li>
					<li class="page-item"><a href="#" class="page-link">5</a></li>
					<li class="page-item"><a href="#" class="page-link">Next</a></li>
				</ul>
			</div>
		</div>
	</div>        
</div>
	<!-- Crud Modal HTML -->
	<div id="crudModal" class="modal fade">
	<div class="modal-dialog">
		<div class="modal-content">
				<div class="modal-header">						
					<h4 class="modal-title">Gestion Fuente</h4>
					<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
				</div>
				<div class="modal-body">					
					<div class="form-group">
						<label>ID</label>
						<asp:TextBox ID="txtId1" runat="server"  class="form-control"></asp:TextBox>
					</div>
					<div class="form-group">
						<label>Nombre</label>
						<asp:TextBox ID="txtNombre1" runat="server"  class="form-control"></asp:TextBox>
					</div>
					<div class="form-group">
						<asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-success" OnCommand="BtnGuardar"  />
						<asp:Button ID="btnConsultar" runat="server" Text="Consultar" class="btn btn-success" OnCommand="BtnConsultar" />
						<asp:Button ID="btnModificar" runat="server" Text="Modificar" class="btn btn-warning" OnCommand="BtnModificar"    />
						<asp:Button ID="btnBorrar" runat="server" Text="Borrar" class="btn btn-warning" OnCommand="BtnBorrar"  />
					</div>					
				</div>
				<div class="modal-footer">
					<input type="button" class="btn btn-default" data-dismiss="modal" value="Cancel">
				</div>
		</div>
	</div>
</div>
</div>
</asp:Content>





