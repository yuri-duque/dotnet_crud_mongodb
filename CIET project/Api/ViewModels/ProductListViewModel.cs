﻿using Domain.Enum;

namespace Api.ViewModels
{
    public class ProductListViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public EStatus Status{ get; set; }
    }
}
