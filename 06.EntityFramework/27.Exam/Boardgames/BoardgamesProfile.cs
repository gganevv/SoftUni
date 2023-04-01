namespace Boardgames;

using AutoMapper;

using Boardgames.Data.Models;
using Boardgames.DataProcessor.ImportDto;

public class BoardgamesProfile : Profile
{
    public BoardgamesProfile()
    {
        //Creator
        this.CreateMap<ImportCreatorDto, Creator>()
            .ForMember(c => c.Boardgames, opt => opt.Ignore());

        //Boardgame
        this.CreateMap<ImportBoardgameDto, Boardgame>();

        //Seller
        this.CreateMap<ImportSellerDto, Seller>()
            .ForMember(s => s.BoardgamesSellers, opt => opt.Ignore());
    }
}