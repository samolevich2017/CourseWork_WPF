using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CourseWork_Samolevich.Services.Interfaces {
    
    // Интерфейс для работы со страницами
    public interface IPageShow {

        Page ShowPageMainScreen(); // открывает страницу "Главная"
        Page ShowPageControlScreen(); // открывает страницу "Управление"
        Page ShowPageAuthorizationScreen(); // открывает страницу "Авторизации"
        Page ShowPagePickUpOrder(); // открывает страницу "Забрать заказ"
        Page ShowPageCheckoutScreen(); // открывает страницу "Оформление заказа"
        Page ShowPageInputDataCarScreen(); // открывает вторую страницу "Оформление заказа" - Данные об авто

    } // IPageShow 
}
