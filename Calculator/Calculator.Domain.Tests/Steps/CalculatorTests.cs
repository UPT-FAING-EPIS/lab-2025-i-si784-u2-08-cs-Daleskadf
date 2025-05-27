using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Calculator.Domain.Tests.Steps
{
    [Binding]
    public sealed class CalculatorTests
    {
        private readonly ScenarioContext _scenarioContext;
        public Calculator Calculadora { get; set; }
        private int _operador01 { get; set; }
        private int _operador02 { get; set; }
        private int _resultado { get; set; }
        private Exception? _exceptionLanzada; 

        public CalculatorTests(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            Calculadora = new Calculator();
            _exceptionLanzada = null; 
        }

        [Given("El numero (.*)")]
        public void DadoElNumero(int operando01)
        {
            _operador01 = operando01;
        }

        [Given("el numero (.*)")]
        public void yElNumero(int operando02)
        {
            _operador02 = operando02;
        }

        [When("sumo")]
        public void CuandoSumo()
        {
            _resultado = Calculadora.Add(_operador01, _operador02);
        }

        [When("resto")]
        public void CuandoResto()
        {
            _resultado = Calculadora.Subtract(_operador01, _operador02);
        }

        [When("multiplico")]
        public void CuandoMultiplico()
        {
            _resultado = Calculadora.Multiply(_operador01, _operador02);
        }

        [When("divido")]
        public void CuandoDivido()
        {
            try
            {
                _resultado = Calculadora.Divide(_operador01, _operador02);
            }
            catch (Exception ex)
            {
                _exceptionLanzada = ex; 
            }
        }

        [Then("el resultado es (.*)")]
        public void EntoncesElResultadoDeberiaSer(int resultado)
        {
            Assert.IsNull(_exceptionLanzada, "Se esperaba un resultado pero se lanzó una excepción.");
            Assert.AreEqual(resultado, _resultado); 
        }
    }
}