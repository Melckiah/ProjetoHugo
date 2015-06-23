using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Validation
{
    public static class Validator
    {
        public static void Validate(IValidationEntity entity)
        {
            entity.Validate();
        }
    }
}
