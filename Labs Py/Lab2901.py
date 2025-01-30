class Paciente:
    def __init__(self, nombre, edad, id):
        self.nombre = nombre
        self.edad = edad
        self.id = id
        self.siguiente = None

class ListaPacientes:
    def __init__(self):
        self.cabeza = None

    def agregar_paciente(self, nombre, edad, id):
        nuevo_paciente = Paciente(nombre, edad, id)
        if not self.cabeza:
            self.cabeza = nuevo_paciente
        else:
            actual = self.cabeza
            while actual.siguiente:
                actual = actual.siguiente
            actual.siguiente = nuevo_paciente

    def verificar_paciente(self, id):
        actual = self.cabeza
        while actual:
            if actual.id == id:
                return f'Nombre: {actual.nombre}, Edad: {actual.edad}, ID: {actual.id}'
            actual = actual.siguiente
        return 'Paciente no encontrado'

    def eliminar_paciente(self, id):
        actual = self.cabeza
        previo = None
        while actual:
            if actual.id == id:
                if previo:
                    previo.siguiente = actual.siguiente
                else:
                    self.cabeza = actual.siguiente
                return f'Paciente con ID {id} eliminado'
            previo = actual
            actual = actual.siguiente
        return 'Paciente no encontrado'

    def mostrar_pacientes(self):
        pacientes = []
        actual = self.cabeza
        while actual:
            pacientes.append(f'Nombre: {actual.nombre}, Edad: {actual.edad}, ID: {actual.id}')
            actual = actual.siguiente
        return '\n'.join(pacientes)

    def atender_paciente(self):
        if self.cabeza:
            paciente_atendido = self.cabeza
            self.cabeza = self.cabeza.siguiente
            return f'Atendiendo a {paciente_atendido.nombre}'
        return 'No hay pacientes en la lista'

lista_pacientes = ListaPacientes()
lista_pacientes.agregar_paciente('Juan', 20, '123')
lista_pacientes.agregar_paciente('Maria', 22, '456')
print(lista_pacientes.mostrar_pacientes())
print(lista_pacientes.verificar_paciente('123'))
print(lista_pacientes.eliminar_paciente('123'))
print(lista_pacientes.mostrar_pacientes())
print(lista_pacientes.atender_paciente())
print(lista_pacientes.mostrar_pacientes())