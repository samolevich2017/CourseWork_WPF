using CourseWork_Samolevich.Services.Interfaces;
using CourseWork_Samolevich.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CourseWork_Samolevich.Services {

    // Класс сервис, реализующий методы для показа страниц
    class PageShowService : IPageShow {

        // Отобразить страницу "Главная"
        Page pageMainScreen;
        public Page ShowPageMainScreen() {
            pageMainScreen = new MainScreenPage();
            return pageMainScreen;
        } // ShowPageMainScreen

        // Отобразить страницу "Управление"
        Page pageControlScreen;
        public Page ShowPageControlScreen() {
            pageControlScreen = new ControlScreenPage();
            return pageControlScreen;
        } // ShowControlScreen

        // Отобразить страницу "Авторизация"
        Page pageAuthorizationScreen;
        public Page ShowPageAuthorizationScreen() {
            pageAuthorizationScreen = new AuthorizathionScreenPage();
            return pageAuthorizationScreen;
        } // ShowPageAuthorizationScreen

        // Отобразить страницу "Забрать заказ"
        Page pagePickUpOrder;
        public Page ShowPagePickUpOrder() {
            pagePickUpOrder = new PickUpOrderPage();
            return pagePickUpOrder;
        } // ShowPagePickUpOrder

        // Отобразить страницу "Оформление заказа"
        Page pageCheckoutScreen;
        public Page ShowPageCheckoutScreen() {
            pageCheckoutScreen = new CheckoutScreenPage();
            return pageCheckoutScreen;
        } // ShowPageCheckoutScreen

        // Отобразить вторую страницу "Оформление заказа" - Данные об авто
        Page pageInputCarDataScreen;
        public Page ShowPageInputDataCarScreen() {
            pageInputCarDataScreen = new CheckoutCarScreenPage();
            return pageInputCarDataScreen;
        }// ShowPageInputDataScreen

    } // PageShowService
}
