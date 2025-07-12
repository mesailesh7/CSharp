﻿#nullable disable
using BYSResults;
using HogWildSystem.BLL;
using HogWildSystem.ViewModels;
using Microsoft.AspNetCore.Components;
using System.IO;


namespace HogWildWeb.Components.Pages.SamplePages
{
    public partial class SimpleListToList
    {
        [Inject] protected PartService PartService { get; set; } = default!;

        public List<PartView> Inventory { get; set; } = new();
        public List<InvoiceLineView> ShoppingCart { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            var result = PartService.GetParts(22, "", new List<int>());
            //  assuming the result is successful
            if (result.IsSuccess)
            {
                Inventory = result.Value;
            }

            await InvokeAsync(StateHasChanged);
        }

        private async Task AddPartToCart(int partID)
        {
            var part = Inventory.FirstOrDefault(x => x.PartID == partID);
            if (part != null)
            {
                ShoppingCart.Add(new InvoiceLineView
                {
                    PartID = part.PartID,
                    Description = part.Description,
                    Price = part.Price,
                    Quantity = 0,
                    Taxable = part.Taxable
                });
                Inventory.Remove(part);
                await InvokeAsync(StateHasChanged);
            }
        }

        private async Task RemovePartFromCart(int partID)
        {
            var result = PartService.GetPart(partID);
            //  assuming the result is successful
            if (result.IsSuccess)
            {
                var part = result.Value;
                if (part != null)
                {
                    Inventory.Add(part);
                    Inventory = Inventory.OrderBy(x => x.Description).ToList();

                    var invoiceLine = ShoppingCart.FirstOrDefault(x => x.PartID == partID);
                    if (invoiceLine != null)
                    {
                        ShoppingCart.Remove(invoiceLine);
                    }

                    await InvokeAsync(StateHasChanged);
                }
            }
        }
    }
}
