using CleanTeeth.Domain.Exceptions;

namespace CleanTeeth.Domain.Tests.Exceptions;

// Test unitarios para la clase: BusinessRuleException
[TestClass]
public class BusinessRuleExceptionTests
{
    [TestMethod]
    public void Constructor_WithMessage_CreateExceptionWithMessage()
    {
        // ARRANGE (Preparar)
        // Configurar los datos y objetos necesarios para la prueba
        var expectedMessage = "Esta esta una violación de una regla de negocio";

        // ACT (Actuar)
        // Ejecutar la acción que se desea probar
        var exception = new BusinessRuleException(expectedMessage);

        // ASSERT
        // Verificar que el resultado es el espertado
        Assert.AreEqual(expectedMessage, exception.Message);
    }

    [TestMethod]
    public void Exception_InheritFromBaseException()
    {
        // ARRANGE /ACT (Preparar) (Actuar)
        // Configurar los datos y objetos necesarios para la prueba
        var exception = new BusinessRuleException("Test");

        // ASSERT
        // Verificar que el resultado es el espertado
        Assert.IsTrue(exception is Exception);
    }

    [TestMethod]
    public void Constructor_WithMessage_CreateExceptionCorrectType()
    {
        // ARRANGE (Preparar)
        // Configurar los datos y objetos necesarios para la prueba
        var expectedMessage = "Mensaje de prueba";

        // ACT (Actuar)
        // Ejecutar la acción que se desea probar
        var exception = new BusinessRuleException(expectedMessage);

        // ASSERT
        // Verificar que el resultado es el espertado
        Assert.IsInstanceOfType(exception, typeof(BusinessRuleException));
        Assert.IsInstanceOfType(exception, typeof (Exception));
    }
}


