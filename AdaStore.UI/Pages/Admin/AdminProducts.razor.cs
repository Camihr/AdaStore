using AdaStore.Shared.Conts;
using AdaStore.Shared.Models;
using AdaStore.UI.Shared;
using AdaStore.UI.UI;
using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace AdaStore.UI.Pages.Admin
{
    public partial class AdminProducts
    {
        [CascadingParameter] public MainLayout Layout { get; set; }

        private List<Product> _products;
        private List<Product> _allProducts;
        private List<TableColumn> _columns;
        private string _searchText;
        private string _emptyMessage;

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                Layout.SetTitle("Productos");
            }
        }

        private void SetColumns()
        {
            _columns = new List<TableColumn>()
            {
                new TableColumn(){DisplayName = "Bolsas", NotOrder = true},
                new TableColumn(){PropName = "CreateAt", DisplayName = "Iniciada", IsSelected = true, IsDesc = true},
                new TableColumn(){PropName = "Status", DisplayName = "Estado"},
                new TableColumn(){DisplayName = "Detalle", OptionalClasses ="th-center", NotOrder = true},
            };
        }

        private void Search(string searchText)
        {
            _searchText = searchText;
            Filter();
        }

        private void SetOrder(TableColumn column)
        {
            var selectedColumn = _columns.FirstOrDefault(c => c.IsSelected);

            if (selectedColumn.PropName == column.PropName)
            {
                column.IsDesc = !column.IsDesc;
            }
            else
            {
                selectedColumn.IsSelected = false;
                column.IsSelected = true;
            }

            Order();
        }

        private void Filter()
        {
            if (_allProducts != null)
            {
                if (string.IsNullOrEmpty(_searchText))
                {
                    _products = _allProducts;
                }
                else
                {
                    _products = _allProducts
                            .Where(c => c.Name.ToUpper().Contains(_searchText.ToUpper()))
                            .ToList();
                }
            }

            if (_products == null || !_products.Any())
            {
                _emptyMessage = Conts.NoSearchResults;
            }
            else
            {
                Order();
            }
        }

        private void Order()
        {
            var selectedColumn = _columns.FirstOrDefault(c => c.IsSelected);
            PropertyInfo prop = typeof(Product).GetProperty(selectedColumn.PropName);

            if (selectedColumn.IsDesc)
                _products = _products.OrderByDescending(x => prop.GetValue(x, null)).ToList();
            else
                _products = _products.OrderBy(x => prop.GetValue(x, null)).ToList();
        }
    }
}
