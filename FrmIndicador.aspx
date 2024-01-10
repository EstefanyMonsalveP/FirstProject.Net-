<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FrmIndicador.aspx.cs" Inherits="primeraEntrega.FrmIndicador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ScriptManager ID="ScriptManager1" runat="server" />
  <div>
	<div class="container-xl">
		<div class="table-responsive">
			<div class="table-wrapper">
				<div class="table-title">
					<div class="row">
						<div class="col-sm-6">
							<h2 class="miEstilo">Gestion <b>Indicadores</b></h2>
						</div>
					<div class="col-sm-6">
						<a href="#crudModal" class="btn btn-success" data-toggle="modal"><i class="material-icons">&#xE147;</i> <span>Gestión Indicadores</span></a>						
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
						<th>Codigo</th>
						<th>Nombre</th>
						<th>Objetivo</th>
						<th>Alcance</th>
						<th>Formula</th>
						<th>ID Tipo Indicador</th>
						<th>ID Unidad Medicion</th>
						<th>Meta</th>
						<th>ID Sentido</th>
						<th>ID Frecuencia</th>
						<th>ID Articulo</th>
						<th>ID Literal</th>
						<th>ID Numeral</th>
						<th>ID Paragrafo</th>
						<th>Actions</th>
					</tr>
				</thead>
				<tbody>
					<%
                        for (int i = 0; i < arregloIndicador.Length; i++)
                        {
					%>
					<tr>
						<td>
							<span class="custom-checkbox">
								<input type="checkbox" id="checkbox1" name="options[]" value="1">
								<label for="checkbox1"></label>
							</span>
						</td>
						<td><% Response.Write(arregloIndicador[i].Id); %></td>
						<td><% Response.Write(arregloIndicador[i].Codigo); %></td>
						<td><% Response.Write(arregloIndicador[i].Nombre); %></td>
						<td><% Response.Write(arregloIndicador[i].Objetivo); %></td>
						<td><% Response.Write(arregloIndicador[i].Alcance); %></td>
						<td><% Response.Write(arregloIndicador[i].Formula); %></td>
						<td><% Response.Write(arregloIndicador[i].FkIdTipoIndicador); %></td>
						<td><% Response.Write(arregloIndicador[i].FkIdUnidadMedicion); %></td>
						<td><% Response.Write(arregloIndicador[i].Meta); %></td>
						<td><% Response.Write(arregloIndicador[i].FkIdSentido); %></td>
						<td><% Response.Write(arregloIndicador[i].FkIdFrecuencia); %></td>
						<td><% Response.Write(arregloIndicador[i].FkIdArticulo); %></td>
						<td><% Response.Write(arregloIndicador[i].FkIdLiteral); %></td>
						<td><% Response.Write(arregloIndicador[i].FkIdNumeral); %></td>
						<td><% Response.Write(arregloIndicador[i].FkIdParagrafo); %></td>
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
					<h4 class="modal-title">Indicadores</h4>
					<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
				</div>
				<div class="modal-body">	
					<br>
					<div class="container">
						<br>
						<!-- Nav tabs -->
						<ul class="nav nav-tabs" role="tablist">
							<li class="nav-item">
								<a class="nav-link active" data-toggle="tab" href="#idIndicador">Indicadores</a>
							</li>
							<li class="nav-item">
								<a class="nav-link" data-toggle="tab" href="#idFuentesPorIndicador">Fuentes por Indicador</a>
							</li>
							<li class="nav-item">
								<a class="nav-link" data-toggle="tab" href="#responsableIndicador">Responsables Por Indicador</a>
							</li>
							<li class="nav-item">
								<a class="nav-link" data-toggle="tab" href="#represenVisualIndicador">Representación Visual Por Indicador</a>
							</li>
							<li class="nav-item">
								<a class="nav-link" data-toggle="tab" href="#variablesPorIndicador">Variables Por Indicador</a>
							</li>
						</ul>
						<!-- Tab panes -->
						<div class="tab-content">
							<div id="idIndicador" class="container tab-pane active"><br>
									<div class="form-group">
										<label>ID</label>
										<asp:TextBox ID="txtId1" runat="server"  class="form-control"></asp:TextBox>
									</div>
									<div class="form-group">
										<label>Codigo</label>
										<asp:TextBox ID="txtCodigo" runat="server"  class="form-control"></asp:TextBox>
									</div>
									<div class="form-group">
										<label>Nombre</label>
										<asp:TextBox ID="txtNombre" runat="server"  class="form-control"></asp:TextBox>
									</div>
									<div class="form-group">
										<label>Objetivo</label>
										<asp:TextBox ID="txtObjetivo" runat="server"  class="form-control"></asp:TextBox>
									</div>
									<div class="form-group">
										<label>Alcance</label>
										<asp:TextBox ID="txtAlcance" runat="server"  class="form-control"></asp:TextBox>
									</div>
									<div class="form-group">
										<label>Formula</label>
										<asp:TextBox ID="txtFormula" runat="server"  class="form-control"></asp:TextBox>
									</div>
									<div class="form-group">
										<label>Tipo indicador</label>
										<asp:DropDownList ID="ddlIdIndicador" runat="server" class="form-control"></asp:DropDownList>
									</div>
									<div class="form-group">
										<label>Unidad Medicion</label>
										<asp:DropDownList ID="ddlIdUnidadM" runat="server" class="form-control"></asp:DropDownList>
									</div>
									<div class="form-group">
										<label>Meta</label>
										<asp:TextBox ID="txtMeta" runat="server"  class="form-control"></asp:TextBox>
									</div>
									<div class="form-group">
										<label>Sentido</label>
										<asp:DropDownList ID="ddlIdSentido" runat="server" class="form-control"></asp:DropDownList>
									</div>
									<div class="form-group">
										<label>Frecuencia</label>
										<asp:DropDownList ID="ddlIdFrecuencia" runat="server" class="form-control"></asp:DropDownList>
									</div>
									<div class="form-group">
										<label>Articulo</label>
										<asp:DropDownList ID="ddlIdArticulo" runat="server" class="form-control"></asp:DropDownList>
									</div>
									<div class="form-group">
										<label>Literal</label>
										<asp:DropDownList ID="ddlIdLiteral" runat="server" class="form-control"></asp:DropDownList>
									</div>
									<div class="form-group">
										<label>Numeral</label>
										<asp:DropDownList ID="ddlIdNumeral" runat="server" class="form-control"></asp:DropDownList>
									</div>
									<div class="form-group">
										<label>Paragrafo</label>
										<asp:DropDownList ID="ddlIdParagrafo" runat="server" class="form-control"></asp:DropDownList>
									</div>
								<div class="form-group">
									<asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-success" OnCommand="BtnGuardar"  />
									<asp:Button ID="btnConsultar" runat="server" Text="Consultar" class="btn btn-success" OnCommand="BtnConsultar" />
									<asp:Button ID="btnModificar" runat="server" Text="Modificar" class="btn btn-warning" OnCommand="BtnModificar"    />
									<asp:Button ID="btnBorrar" runat="server" Text="Borrar" class="btn btn-warning" OnCommand="BtnBorrar"  />
								</div>
							</div>
							<div id="idFuentesPorIndicador" class="container tab-pane fade"><br>
								<asp:UpdatePanel ID="UpdatePanel1" runat="server">
									<ContentTemplate>
								<div class="form-group">
									<label>Fuentes</label>
									<asp:DropDownList ID="ddlFuentes" runat="server" class="form-control"></asp:DropDownList>
								</div>
								<div class="form-group">
									<label>Fuentes por Indicador</label>
									<asp:ListBox ID="lbFuentes" runat="server" class="form-control"></asp:ListBox>
								</div>
								<div class="form-group">
									<asp:Button ID="btnAgregar" runat="server" Text="Agregar" class="btn btn-success" OnClick="BtnAgregar"  />
									<asp:Button ID="btnRemover" runat="server" Text="Remover" class="btn btn-success" OnClick="BtnRemover" />
								</div>
							</ContentTemplate>
						</asp:UpdatePanel>
							</div>
							<div id="responsableIndicador" class="container tab-pane fade"><br>
								<asp:UpdatePanel ID="UpdatePanel2" runat="server">
								<ContentTemplate>
								<div class="form-group">
									<label>Responsables</label>
									<asp:DropDownList ID="ddlResponsables" runat="server" class="form-control"></asp:DropDownList>
								</div>
								<div class="form-group">
									<label>Responsables por Indicador</label>
									<asp:ListBox ID="lbResponsables" runat="server" class="form-control"></asp:ListBox>
								</div>

								<div class="form-group">
									<label>Fecha Asignación yyyy/mm/dd</label>
									<asp:TextBox ID="txtFechaAsignacion" runat="server" CssClass="form-control" placeholder="yyyy-MM-dd"></asp:TextBox>
								</div>
								<div class="form-group">
									<asp:Button ID="btnAddResponsable" runat="server" Text="Agregar" class="btn btn-success" OnClick="BtnAddResponsable"/>
									<asp:Button ID="btnRemoveResponsable" runat="server" Text="Remover" class="btn btn-success" OnClick="BtnRemoveResponsable"/>
								</div>
									</ContentTemplate>
								</asp:UpdatePanel>
							</div>
							<div id="represenVisualIndicador" class="container tab-pane fade"><br>
								<asp:UpdatePanel ID="UpdatePanel3" runat="server">
									<ContentTemplate>
								<div class="form-group">
									<label>Representacion visual</label>
									<asp:DropDownList ID="ddlRepresenVisualindicador" runat="server" class="form-control"></asp:DropDownList>
								</div>
								<div class="form-group">
									<label>Representación Visual por Indicador</label>
									<asp:ListBox ID="lbRepresenVisualIndicador" runat="server" class="form-control"></asp:ListBox>
								</div>
								<div class="form-group">
									<asp:Button ID="btnAddRepresen" runat="server" Text="Agregar" class="btn btn-success" OnClick="BtnAddRepresen"  />
									<asp:Button ID="btnRemoveRepresen" runat="server" Text="Remover" class="btn btn-success" OnClick="BtnRemoveRepresen" />
								</div>
									</ContentTemplate>
								</asp:UpdatePanel>
							</div>
								<div id="variablesPorIndicador" class="container tab-pane fade"><br>
									<asp:UpdatePanel ID="UpdatePanel4" runat="server">
										<ContentTemplate>
									<div class="form-group">
										<label>Variables</label>
										<asp:DropDownList ID="ddlVariables" runat="server" class="form-control"></asp:DropDownList>
									</div>
									<div class="form-group">
										<label>Dato por indicador</label>
											<asp:TextBox ID="txtDato" runat="server"  class="form-control"></asp:TextBox>
									</div>
									<div class="form-group">
										<label>Email</label>
										<asp:DropDownList ID="ddlEmail" runat="server" class="form-control"></asp:DropDownList>
									</div>
									<div class="form-group">
										<label>Fecha Dato yyyy/mm/dd</label>
										<asp:TextBox ID="txtFechaDato" runat="server" CssClass="form-control" placeholder="yyyy-MM-dd"></asp:TextBox>
									</div>
									<div class="form-group">
										<label>Variables por Indicador</label>
										<asp:ListBox ID="lbVariablesIndicador" runat="server" class="form-control"></asp:ListBox>
									</div>
									<div class="form-group">
										<asp:Button ID="btnAddVariables" runat="server" Text="Agregar" class="btn btn-success" OnClick="BtnAddVariables"/>
										<asp:Button ID="btnRemoveVariables" runat="server" Text="Remover" class="btn btn-success" OnClick="BtnRemoveVariables" />
									</div>
								</ContentTemplate>
							</asp:UpdatePanel>
								</div>
							</div>
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

