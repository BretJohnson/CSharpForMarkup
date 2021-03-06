﻿using System;
using CSharpForMarkup;
using CSharpForMarkupExample.ViewModels;
using CSharpForMarkupExample.Views.Controls;
using Xamarin.Forms;
using static CSharpForMarkup.EnumsForGridRowsAndColumns;

namespace CSharpForMarkupExample.Views.Pages
{
    public class MainPage : BaseContentPage<MainViewModel>
    {
        enum PageRow { Header, Body }

        public MainPage()
        {
            var app = App.Current;
            var vm = ViewModel = app.MainViewModel;
            
            NavigationPage.SetHasNavigationBar(this, false);

            BackgroundColor = Colors.BgGray3.ToColor();

            Content = new Grid 
            {
                RowSpacing = 0,

                RowDefinitions = Rows.Define(
                    (PageRow.Header, GridLength.Auto),
                    (PageRow.Body  , GridLength.Star)
                ),

                Children = {
                    PageHeader.Create(
                        PageMarginSize, 
                        nameof(vm.Title), nameof(vm.SubTitle)
                    ) .Row (PageRow.Header),

                    new ScrollView { Content = new StackLayout { Children = {
                        new Button { Text = nameof(RegistrationCodePage), Style = Styles.ButtonFilled }
                            .FillExpandH() .Margin(PageMarginSize) .Height(44)
                            .Bind(nameof(vm.ContinueToRegistrationCommand)),

                        new Button { Text = nameof(NestedListPage), Style = Styles.ButtonFilled }
                            .FillExpandH() .Margin(PageMarginSize) .Height(44)
                            .Bind(nameof(vm.ContinueToNestedListCommand)),
                    }}} .Row(PageRow.Body)
                 }
            };
        }
    }
}
