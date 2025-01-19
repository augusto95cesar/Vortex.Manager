let tags = [];
var app = {
    init: () => {
        this.app.getNoticias(app.atualizarListaNoticias);
        this.app.getTags(app.atualizarListaTags)
        this.app.modal();
    },
    getNoticias: (callback) => {
        $.ajax({
            url: '/Noticias/Get',
            type: 'GET',
            dataType: 'json', success: function (data) {
                callback(data);
            },
            error: function (error) {
                console.log("Erro getNoticias:", error);
            }
        });
    },
    atualizarListaNoticias: (noticias) => {        
        noticias.forEach(function (noticia) {
            var tagsHtml = ''
            noticia.tags.forEach((tag) => {             
                tagsHtml += `<a style="background:#1a5e8f; color:white;" 
                                class="badge me-2 mb-2 
                                text-decoration-none"  id="tag-noticia_${tag.codigo}">
                                    ${tag.descricao}
                               </a> `;
            })
            $("#body-noticias").prepend(
                `<div class="container mt-5" id="${noticia.codigo}">
                        <div class="card">
                            <div class="card-header">
                                <h5 class="card-title">${noticia.titulo}</h5>
                            </div>
                            <div class="card-body">
                                <p class="card-text">
                                    ${noticia.descricao}
                                </p>
                                <div class="mt-3">
                                    <h6>Tags:</h6>
                                    <div class="d-flex flex-wrap">
                                        ${tagsHtml}
                                    </div>
                                </div>
                            </div>
                        </div> 
                    </div>` 
            );
        }); 
    },
    getTags: (callback) => {
        $.ajax({
            url: '/Tags/Get',
            type: 'GET',
            dataType: 'json', success: function (data) {
                callback(data);
            },
            error: function (error) {
                console.log("Erro getTags:", error);
            }
        });
    },
    creatTag: (tagName) => {
        var tag = {
            descricao: tagName
        };

        $.ajax({
            url: '/Tags/Create', // URL da sua Action
            type: 'POST',
            data: tag, // Dados a serem enviados
            dataType: 'json',
            success: function (data) {
                app.getTags(app.atualizarListaTags); 
            },
            error: function (error) {
                console.log("Erro na requisição AJAX:", error);
            }
        });
    },
    creatNoticia: (listTagsId) => {
        var titulo = $("#modalTitulo").val();
        var descricao = $("#modalDescricao").val();

        var noticias = {
            titulo: titulo,
            texto: descricao,
            tagsid: listTagsId
        }

        $.ajax({
            url: '/Noticias/Create', // URL da sua Action
            type: 'POST',
            data: noticias, // Dados a serem enviados
            dataType: 'json',
            success: function (data) {
                //console.log("teste de info",data)
                app.atualizarListaNoticias(data);
                app.fecharModal(); 
            },
            error: function (error) {
                console.log("Erro creatNoticia:", error);
            }
        });
    },
    modal: () => {
        $("#addTag").click(function () {
            const tagName = $("#tagName").val().trim();
            if (tagName !== "" && !tags.includes(tagName)) {
                app.creatTag(tagName);
            }
        });
        $("#addTagDisplay").click(function () {
            var display = $("#tagForm").css("display");
            if (display === 'block') {
                $("#tagForm").css("display", "none");
            } else {
                $("#tagForm").css("display", "block");
            }
        });
        $("#saveNoticia").click(function () {
            var tagsSelecionadas = [];
            $("#tagList input:checked").each(function () {
                tagsSelecionadas.push($(this).val());
            });
            app.creatNoticia(tagsSelecionadas);
        });
        $('#tagModal').on('shown.bs.modal', function () {
            app.getTags(app.atualizarListaTags);
        })
    },
    atualizarListaTags: (listTags) => {
        $("#tagName").val("");
         tags = listTags;
         $("#tagList").empty();
        if (tags.length === 0) {
            $("#tagList").append("<p>Nenhuma tag cadastrada.</p>");
        } else {
            tags.forEach(function (tag, index) {
                $("#tagList").append(`
                            <div class="form-check">
                                <input class="form-check-input" type="checkbox" value="${tag.codigo}" id="tagCheck${index}">
                                <label class="form-check-label" for="tagCheck${index}">
                                    ${tag.descricao}
                                </label>
                            </div>
                        `);
            });
        }
    },
    fecharModal: () => {
        $("#tagModal").modal('hide');
    }
}

//iniciar javascript
app.init();