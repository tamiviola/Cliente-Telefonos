@ModelType EE.Alumno

@Code
    ViewData("Title") = "Crear"
End Code

<h2>Crear</h2>

@Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>Alumno</legend>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Nombre)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Nombre)
            @Html.ValidationMessageFor(Function(model) model.Nombre)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Apellido)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Apellido)
            @Html.ValidationMessageFor(Function(model) model.Apellido)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.FechaNac)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.FechaNac)
            @Html.ValidationMessageFor(Function(model) model.FechaNac)
        </div>
        <div class="editor-label">
            <label>Facultad</label>
            @Html.DropDownListFor(Function(model) model.Facultad.Id, New SelectList(ViewBag.Facultades, "Id", "Nombre"), "")
            @Html.ValidationMessageFor(Function(model) model.Facultad.Id)
        </div>
        <div class="editor-field">
            <label>Telefonos</label>

            <ul id="telefonos">
                @Code
                    If Model IsNot Nothing Then
                        For index = 0 To Model.Telefonos.Count() - 1
                            Dim i = index
                            @<li>
                                <label>Número</label>
                                @Html.TextBoxFor(Function(model) model.Telefonos(i).Numero)
                                @Html.ValidationMessageFor(Function(model) model.Telefonos(i).Numero)
                                <label>Zona</label>
                                @Html.TextBoxFor(Function(model) model.Telefonos(i).Zona)
                                @Html.ValidationMessageFor(Function(model) model.Telefonos(i).Zona)
                                <label>Detalle</label>
                                @Html.DropDownListFor(Function(model) model.Telefonos(i).Detalle, New List(Of SelectListItem)() From { _
                                            New SelectListItem() With {.Text = "Hogar", .Value = "Hogar"},
                                            New SelectListItem() With {.Text = "Personal", .Value = "Personal"},
                                            New SelectListItem() With {.Text = "Laboral", .Value = "Laboral"}
                                    }, "")
                                @Html.ValidationMessageFor(Function(model) model.Telefonos(i).Detalle)
                            </li>
                        Next
                    End If
                End Code
            </ul>
            <button type="button" class="btn default" id="btnQuitar">Quitar Telefono</button>
            <button type="button" class="btn default" id="btnAgregar">Agregar Teléfono...</button>
        </div>

        <p>
            <input type="submit" value="Crear" />
        </p>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Volver", "Index")
</div>

<script>
    //Cuando se termina de cargar la pagina
    //document.addEventListener("load", function () {


    //});

    var btnAgregar = document.getElementById("btnAgregar");
    //Cuando se hace click en el boton Agregar
    btnAgregar.addEventListener("click", function () {
        var indexTelefono = cantidadHijosLi("telefonos");
        var ul = document.getElementById("telefonos");
        ul.innerHTML +=
        "<li>" +
            "<label>Número</label>" +
            "<input type='text' name='Telefonos[" + indexTelefono + "].Numero' value='' />" +
            "<label>Zona</label>" +
            "<input type='text' name='Telefonos[" + indexTelefono + "].Zona' value='' />" +
            "<label>Detalle</label>" +
            "<select name='Telefonos[" + indexTelefono + "].Detalle'>" +
                "<option value='Hogar'>Hogar</option>" +
                "<option value='Personal'>Personal</option>" +
                "<option value='Laboral'>Laboral</option>" +
            "</select>" +
        "</li>";
    });

    var btnQuitar = document.getElementById("btnQuitar");
    //Cuando se hace click en el boton Quitar
    btnQuitar.addEventListener("click", function () {
        var ul = document.getElementById("telefonos");
        ul.removeChild(ul.lastChild);
    });

    function cantidadHijosLi(ulId){
        var ul = document.getElementById(ulId);
        var liNodes = [];

        for (var i = 0; i < ul.childNodes.length; i++) {
            if (ul.childNodes[i].nodeName == "LI") {
                liNodes.push(ul.childNodes[i]);
            }
        }
        return liNodes.length;
    }
</script>
