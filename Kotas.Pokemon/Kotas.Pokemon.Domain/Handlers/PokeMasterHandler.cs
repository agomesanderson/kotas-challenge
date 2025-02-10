using Kotas.Pokemon.Domain.Commands.Input.PokeMasters;
using Kotas.Pokemon.Domain.Commands.Output;
using Kotas.Pokemon.Domain.Entities;
using Kotas.Pokemon.Domain.Repositories;
using Kotas.Pokemon.Infra.Common.Contracts;

namespace Kotas.Pokemon.Domain.Handlers;

public class PokeMasterHandler
{
    private readonly IPokeMasterRepository _pokeMasterRepository;

    public PokeMasterHandler(IPokeMasterRepository pokeMasterRepository)
    {
        _pokeMasterRepository = pokeMasterRepository;
    }

    public async Task<ICommandResult> Handle(int id)
    {
        var pokeMaster = await _pokeMasterRepository.Get(id);

        return new GenericCommandResult(true, "PokeMaster carregado com sucesso", new { pokeMaster });
    }

    public async Task<ICommandResult> Handle(CreatePokeMasterCommand command)
    {
        command.Validate();

        if (!command.IsValid)
            return new GenericCommandResult(false, "PokeMaster inválido", command.Notifications);

        var pokemon = PokeMaster.Create(command);

        var result = await _pokeMasterRepository.Insert(pokemon);

        return new GenericCommandResult(true, "PokeMaster cadastrado com sucesso", new { Id = result });
    }
}
