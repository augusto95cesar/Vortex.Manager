using Vortex.Manager.Application.DTOs.Input.Noticia;

namespace Vortex.Manager.Application.Validations
{
    public static class NoticiaValidation
    {
        public static void Validation(this RequestNoticiaDTO dto)
        { 
            var qtdTags = dto.TagsId?.Count ?? 0;
            if (qtdTags == 0)
                throw new Exception("Nenhuma Tag Selecionada.");

            var titulo = dto.Titulo ?? "";
            if (titulo.Length > 250)
                throw new Exception("O campo Título pode ter no máximo 250 caracteres.");

            if (titulo.Length == 0)
                throw new Exception("O campo Título não foi preenchido.");

            var texto = dto.Texto ?? "";
            if (texto.Equals(""))
                throw new Exception("O campo Descrição não foi preenchido.");


        }
    }
}
