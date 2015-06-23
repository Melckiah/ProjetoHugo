using Infrastructure.Services.Helper;
using Infrastructure.Services.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Exceptions;

namespace Domain.Model.Entity
{
    public class Post : IValidationEntity
    {
        public long PostId { get; set; }

        public string PostMessage { get; set; }

        public DateTime PostDate { get; set; }

        public string DisplayPostDate 
        {
            get
            {
                return DateTimeHelper.ToDateString(PostDate);
            }
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(PostMessage))
                throw new PostMessageException("A mensagem do post está vazia.");
            if (PostMessage.Length > 140)
                throw new PostMessageException("O número de caracteres não pode ser maior que 140.");
            if (PostDate > DateTime.Now)
                throw new PostMessageException("A data do Post não pode ser maior que a data atual.");
        }
    }
}
