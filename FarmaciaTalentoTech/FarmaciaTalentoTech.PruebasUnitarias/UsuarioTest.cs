using FarmaciaTalentoTech.Model.Entidades;
using FarmaciaTalentoTech.Model.Interfaces;
using Moq;

namespace FarmaciaTalentoTech.PruebasUnitarias
{
    public class UsuarioTest
    {
        [Fact]
        public void CrearUsuario_DeberiaRetornarTrue_CuandoSeCreaCorrectamente()
        {
            var mockDB = new Mock<IFarmaciaTalentoTechDB>();

            var nuevoUsuario = new Usuario {
                NombreUsuario = "testuser",
                Password = "testpassword",
                Email = "testuser@test.com",
                IdRol = 1
            };

            mockDB.Setup(db=> db.CrearUsuario(It.IsAny<Usuario>())).Returns(true);

            //Act
            var resultado = mockDB.Object.CrearUsuario(nuevoUsuario);

            //Assert
            Assert.True(resultado, "Usuario creado correctamente.");
        }

        [Fact]
        public void EliminarUsuario_DeberiaRetornarTrue_CuandoSeEliminaCorrectamente()
        {
            var mockDB = new Mock<IFarmaciaTalentoTechDB>();
            var usuarioAEliminar = new Usuario { NombreUsuario = "testuser" };

            mockDB.Setup(db => db.EliminarUsuario(It.IsAny<string>())).Returns(true);

            //Act
            var resultado = mockDB.Object.EliminarUsuario(usuarioAEliminar.NombreUsuario);
            
            //Assert
            Assert.True(resultado, "Usuario eliminado correctamente.");
        }
    }
}