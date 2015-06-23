using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Helper
{
    public static class DateTimeHelper
    {
        public static string ToDateString(DateTime dateTime)
        {
            TimeSpan diferenca = DateTime.Now - dateTime;

            //Verifica se a apresentação é em minutos
            if (diferenca.TotalMinutes < 60)
            {
                if (diferenca.TotalMinutes < 2)
                    return "1 minuto atrás";
                return string.Format("{0} minutos atrás",
                                            (int)diferenca.TotalMinutes);
            }
            else if (diferenca.TotalHours < 24)
            {
                if (diferenca.TotalHours < 2)
                    return "1 hora atrás";
                return string.Format("{0} horas atrás",
                                            (int)diferenca.TotalHours);
            }
            else if (diferenca.TotalDays < 7)
            {
                if (diferenca.TotalDays < 2)
                    return "1 dia atrás";
                return string.Format("{0} dias atrás",
                                            (int)diferenca.TotalDays);
            }
            else if (diferenca.TotalDays < 30)
            {
                int semana = (int)diferenca.TotalDays / 7;
                if (semana < 2)
                    return "1 semana atrás";
                return string.Format("{0} semanas atrás",
                                            semana);
            }
            else
            {
                DateTime dt = new DateTime(diferenca.Ticks);

                int mes = (int)diferenca.TotalDays / 30;
                if (mes < 2)
                    return "1 mês atrás";
                return string.Format("{0} meses atrás",
                                            mes);
            }
        }
    }
}
