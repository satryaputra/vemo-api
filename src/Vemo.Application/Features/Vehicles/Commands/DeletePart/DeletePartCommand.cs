namespace Vemo.Application.Features.Vehicles.Commands.DeletePart;

public class DeletePartCommand : IRequest<object>
{
    public Guid PartId { get; set; }
}