# API de Tramitación de Documentos
  
El sistema permite gestionar trámites de **DNI** y **Pasaportes** (Regular y Express).  
No existen usuarios registrados en el sistema ya que los trámites pueden hacerse desde una unidad básica o kiosco.  

---

## Requerimientos Cubiertos

1. **Consultar trámites disponibles y costo**  
   - Endpoint: `GET /Tramite/GetLosTramitesActivos`  
   - Retorna lista de trámites ordenados por precio de menor a mayor.

2. **Registrar al titular del trámite**  
   - Endpoint: `POST /Titular/RegistrarTitular`  
   - Permite registrar a la persona destinataria del DNI o Pasaporte.  

3. **Activar/Desactivar trámites**  
   - Endpoint: `PUT /Tramite/CambiarEstado/{id}`  
   - Permite cambiar el estado del Tramite, activado(1) o desactivado(0).

4. **Modificar precio de un trámite**  
   - Endpoint: `PUT /ActualizarPrecio/{id}`  

5. **Listar titulares extranjeros**  
   - Endpoint: `GET /Titular/GetTitularesExtranjeros`  
   - Retorna titulares con DNI comenzado en 92, 93, 94 o 95 millones.  

---

## Ejecución

1. Clonar el repositorio  
2. Restaurar dependencias con `dotnet restore`  
3. Ejecutar el proyecto con `dotnet run`  
4. La API estará disponible en `https://localhost:5001`

---

## Notas
- El **Pasaporte Express** no está disponible hasta la segunda semana después de la puesta en producción.  
- Se trata de un **MVP**: no se valida la existencia previa del titular.  
