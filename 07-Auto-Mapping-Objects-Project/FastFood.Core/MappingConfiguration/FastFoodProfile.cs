namespace FastFood.Core.MappingConfiguration
{
    using System;
    using System.Globalization;
    using System.Net;
    using AutoMapper;
    using FastFood.Core.ViewModels.Categories;
    using FastFood.Core.ViewModels.Employees;
    using FastFood.Core.ViewModels.Items;
    using FastFood.Core.ViewModels.Orders;
    using FastFood.Models;
    using FastFood.Models.Enums;
    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            //Categories

            this.CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(x => x.Name, opt => opt.MapFrom(c => c.CategoryName));

            //this.CreateMap<Category, CategoryAllViewModel>()
            //    .ForMember(x => x.Name, opt => opt.MapFrom(cavm => cavm.Name));
            //this above is not needed Category and CategoryAllViewModel have same mamberName = Name

            this.CreateMap<Category, CategoryAllViewModel>();

            //Employees

            this.CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(revm => revm.PositionId, opt => opt.MapFrom(p => p.Id))
                .ForMember(revm => revm.PositionName, opt => opt.MapFrom(p => p.Name));

            this.CreateMap<RegisterEmployeeInputModel, Employee>();

            this.CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(eavm => eavm.Position, opt => opt.MapFrom(e => e.Position.Name));

            //Items
            this.CreateMap<Category, CreateItemViewModel>()
                .ForMember(civm => civm.CategoryId, opt => opt.MapFrom(c => c.Id))
                .ForMember(civm => civm.CategoryName, opt => opt.MapFrom(c => c.Name));

            this.CreateMap<CreateItemInputModel, Item>();

            this.CreateMap<Item, ItemsAllViewModels>()
                .ForMember(iavl => iavl.Category, opt => opt.MapFrom(i => i.Category.Name));

            //Orders
            this.CreateMap<Item, CreateOrderItemViewModel>()
                .ForMember(coivm => coivm.ItemId, opt => opt.MapFrom(i => i.Id))
                .ForMember(coivm => coivm.ItemName, opt => opt.MapFrom(i => i.Name));

            this.CreateMap<Employee, CreateOrderEmployeeViewModel>()
                .ForMember(coevm => coevm.EmployeeID, opt => opt.MapFrom(e => e.Id))
                .ForMember(coevm => coevm.EmployeeName, opt => opt.MapFrom(e => e.Name));

            this.CreateMap<CreateOrderInputModel, Order>()
                .ForMember(o => o.DateTime, opt => opt.MapFrom(coim => DateTime.UtcNow))
                .ForMember(o => o.Type, opt => opt.MapFrom(coim => OrderType.ToGo));

            this.CreateMap<CreateOrderInputModel, OrderItem>()
                .ForMember(oi => oi.ItemId, opt => opt.MapFrom(coim => coim.ItemId))
                .ForMember(oi => oi.Quantity, opt => opt.MapFrom(coim => coim.Quantity));

            this.CreateMap<Order, OrderAllViewModel>()
                .ForMember(oavm => oavm.Employee, opt => opt.MapFrom(o => o.Employee.Name))
                .ForMember(oavm => oavm.DateTime, opt => opt.MapFrom(o => o.DateTime.ToString("D", CultureInfo.InvariantCulture)))
                .ForMember(oavm => oavm.OrderId, opt => opt.MapFrom(o => o.Id));
        }
    }
}
