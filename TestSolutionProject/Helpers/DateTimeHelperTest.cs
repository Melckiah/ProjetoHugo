using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infrastructure.Services.Helper;

namespace TestSolutionProject.Helpers
{
    [TestClass]
    public class DateTimeHelperTest
    {                

        [TestMethod]
        public void Teste_Minuto_UmAtras()
        {
            string resultado = DateTimeHelper.ToDateString(DateTime.Now.AddMinutes(-1));
            Assert.AreEqual("1 minuto atrás", resultado);
        }

        [TestMethod]
        public void Teste_Minuto_DoisAtras()
        {
            string resultado = DateTimeHelper.ToDateString(DateTime.Now.AddMinutes(-2));
            Assert.AreEqual("2 minutos atrás", resultado);
        }

        [TestMethod]
        public void Teste_Minuto_TrintaAtras()
        {
            string resultado = DateTimeHelper.ToDateString(DateTime.Now.AddMinutes(-30));
            Assert.AreEqual("30 minutos atrás", resultado);
        }

        [TestMethod]
        public void Teste_Hora_UmaAtras()
        {
            string resultado = DateTimeHelper.ToDateString(DateTime.Now.AddHours(-1));
            Assert.AreEqual("1 hora atrás", resultado);
        }

        [TestMethod]
        public void Teste_Hora_DuasAtras()
        {
            string resultado = DateTimeHelper.ToDateString(DateTime.Now.AddHours(-2));
            Assert.AreEqual("2 horas atrás", resultado);
        }

        [TestMethod]
        public void Teste_Hora_DezAtras()
        {
            string resultado = DateTimeHelper.ToDateString(DateTime.Now.AddHours(-10));
            Assert.AreEqual("10 horas atrás", resultado);
        }

        [TestMethod]
        public void Teste_Dia_UmAtras()
        {
            string resultado = DateTimeHelper.ToDateString(DateTime.Today.AddDays(-1));
            Assert.AreEqual("1 dia atrás", resultado);
        }

        [TestMethod]
        public void Teste_Dia_DoisAtras()
        {
            string resultado = DateTimeHelper.ToDateString(DateTime.Today.AddDays(-2));
            Assert.AreEqual("2 dias atrás", resultado);
        }

        [TestMethod]
        public void Teste_Dia_CincoAtras()
        {
            string resultado = DateTimeHelper.ToDateString(DateTime.Today.AddDays(-5));
            Assert.AreEqual("5 dias atrás", resultado);
        }

        [TestMethod]
        public void Teste_Semana_UmaAtras()
        {
            string resultado = DateTimeHelper.ToDateString(DateTime.Today.AddDays(-7));
            Assert.AreEqual("1 semana atrás", resultado);
        }

        [TestMethod]
        public void Teste_Semana_DuasAtras()
        {
            string resultado = DateTimeHelper.ToDateString(DateTime.Today.AddDays(-14));
            Assert.AreEqual("2 semanas atrás", resultado);
        }

        [TestMethod]
        public void Teste_Semana_QuatroAtras()
        {
            string resultado = DateTimeHelper.ToDateString(DateTime.Today.AddDays(-29));
            Assert.AreEqual("4 semanas atrás", resultado);
        }

        [TestMethod]
        public void Teste_Mes_UmAtras()
        {
            string resultado = DateTimeHelper.ToDateString(DateTime.Today.AddDays(-30));
            Assert.AreEqual("1 mês atrás", resultado);
        }

        [TestMethod]
        public void Teste_Mes_DoisAtras()
        {
            string resultado = DateTimeHelper.ToDateString(DateTime.Today.AddMonths(-2));
            Assert.AreEqual("2 meses atrás", resultado);
        }
    }
}
