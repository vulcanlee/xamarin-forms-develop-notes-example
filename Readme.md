# AttProp 

##  如何在 Xamarin.Forms 開發 XAML 用的 Attached Property

這個附加屬性，只能夠套用在 Entry 控制項上，會根據所指定的名稱，自動加上浮水印文字

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/AttProp

# BindProp

## 客製控制項並且加入一個可綁定屬性，以便擴充新控制項的能力

繼承原有控制項，並在新的控制項中，加入一個新的可綁定屬性，使得新的控制項可以具有另外一種表現能力

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/BindProp

# DynaStat

## 資源字典的靜態與動態資源項目的使用範例

在這個範例中，將會展示如何在 Xamarin.Forms 中使用靜態與動態資源，並且如何在執行時期來變更動態資源的用法，也會展示出資源項目的繼承關係與變化。另外，也會練習使用 .NET 的靜態屬性作為 XAML 屬性的設定值。

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/DynaStat

# ElementTree

## 資源樣式的定義與使用說明

說明如何使用資源樣式的用法，並且了解到階層式的資源樣式用法與覆蓋方式

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/ElementTree

# ImageCircleLab

## 顯示一有圓形遮罩修飾過的個圖片

要讓圖片被圓形遮罩給修飾，您需要定義額外命名空間，指向 ImageCircle 這套件的組件，就可以將有圓形遮罩的圖片，顯示在螢幕上

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/ImageCircleLab

# MergedDict

## 資料字典合併的用法

我們可以將資料字典定義在另外一個 .xaml 檔案中，並且在您要顯示的頁面中，將這個資料字典定義的內容，合併進來使用，是個相當實用的功能，因為，您可以將常用的資料字典資源整理在一個地方，方便管理。
您將會學習到如何定義資源項目、明確樣式、隱含樣式、控制項自己宣告資源字典、合併資源字典、宣告樣式但繼承某個已宣告的樣式、樣式的繼承(合併不會跨檔案繼承)。

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/MergedDict

# MVVM1

## 開發 Xamarin.Forms 專案，不使用 MVVM 開發方式的作法

MVVM 是您要開發 Xamarin.Forms 專案時候必備的開發技能，若您不使用 MVVM 開發方式與選擇一個合適您的 MVVM 開發框架工具；那麼，當您進行專案開發的時候，將會遇到很多不方便處理的問題。

在這裡將會體驗如何使用 Code Behind 的方式來開發 Xamarin.Forms 的專案

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/MVVM1

# MVVM2

## 不透過任何 MVVM 開發套件，自行製作 MVVM 開發方法的規範需求

若您不依賴任何 MVVM 開發框架工具，則您需要在每個 ViewModel 內來實作出 INotifyPropertyChanged (INPC) 介面，如此，當 View 中的控制項所綁定的屬性或者 ViewModel 內的屬性有異動的時候，才會根據綁定模式，自動地進行異動後的資料更新。

在這個專案中，您將需要定義一個 ViewModel 類別，並且設定頁面中的 BindingContext 屬性上。

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/MVVM2

# MVVM3

## 使用 Prism 開發框架工具，進行 Xamarin.Forms + MVVM 專案開發

在這個練習專案中，我們將會直接使用 Prism 這個 MVVM Framework；Prism 提供了相當多友善的 MVVM 開發解決方案，讓您在進行 Xamarin.Forms 專案開發的時候，可以，更加快速與簡潔的做出好用的應用程式。

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/MVVM3

# PickerLab 

## 在 Xamarin.Forms 中使用具有可綁定功能的 Picker 控制項

在 Xamarin.Forms 中的 Picker 控制項，是沒有提供可綁定資料與命令功能，這對於採用 MVVM 開發方式的開發者而言，是相當的不方便(不過，在2017第二季之後，Xamarin.Forms 將會提供這項功能)。

不過，在此之前，若想要使用這樣的功能，您可以使用本範例中提供的 BindablePicker 來做這樣功能，您也可以順便學習與了解，在 Xamarin.Forms 中，要如何自己客製化一個控制項，做出屬於您自己的 XAML 控制項。

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/PickerLab

# sampleListView

## 練習如何使用 ListView 控制項

學習 Xamarin.Forms 的 ListView 使用方法：產生一個 ViewModel類別，將 ViewModel 綁訂到 ListView 上、定義每筆紀錄要顯示的視覺內容

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/sampleListView

# XFAlert

## 學習如何使用 Xamarin.Forms 提供的對話窗功能

您可以在 Code Behind 程式碼中，直接使用 DisplayAlert / DisplayActionSheet 對話窗，這些對話窗將會在每個平台，以原生對話窗的樣貌出現(因為，就是呼叫原生平台的對話窗 API)。

另外，我們也將學習如何在 ViewModel 中使用 Prism 提供的 IPageDialogService 介面的 DisplayAlertAsync / DisplayActionSheetAsync 對話窗功能；在這裡，您需要在 ViewModel 的建構式中，注入 IPageDialogService 實作物件。

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/XFAlert

# XFALM

## Xamarin.Forms 內提供的頁面應用程式生命週期練習

在這裡，我們將會學習兩個事件 OnAppearing / OnDisappearing 的使用方式，以及，這兩個事件將會於甚麼時候被執行。透過了 Visual Studio 輸出視窗，您可以看到這些事件被呼叫的過程與順序。

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/XFALM

# XFAnimation

## 學習如何在 Xamarin.Forms 中，使用動畫效果功能

在這裡，您將學習如何使用每個控制項都會具有的動畫處理方法，由於，這些動畫處理方法都是依附在每個控制項中，因此，我們需要在 Code Behind 來撰寫相關動畫處理邏輯，若您想要把這些 Code Behind 程式碼移除，直接在 ViewModel 中呼叫，您可以客製化一個 Behavior。

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/XFAnimation

# XFAttBehavior

## 說明了如何製作出一個 Attached Behaviors

Xamarin.Forms 內的 Behaviors ，讓您可以將一些功能加入到 Xamarin.Forms所提供的控制項中，但是卻不需要繼承原有控制項類別，做出一個客製化控制項；透過了 Attached Behavior ，就可以任您的控制項，擁有不同的行為表現；另外， Behaviors 可以讓您原先在 Code Behind 內的處理邏輯，隱藏起來，透過 XAML 語法，進而啟用這些功能

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/XFAttBehavior

# XFCarouselView

## 練習使用旋轉木馬控制項

這個練習中，將會學習如何在 Xamarin.Forms 中使用旋轉木馬控制項。

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/XFCarouselView

# XFEllipse

## 在 Xamarin.Forms 應用程式，可以產生橢圓或圓形的圖形

我們將會來練習一個 Xamarin.Forms 內沒有的一個控制項，那就是要顯示圓形或者橢圓的形狀；在這裡將會繼承 View 控制項，產生出一個 EllipseView 新控制項，並且使用 Renderer 核心功能，在 Android / iOS / UWP 內，使用原生 API 來產生出這個圓形或橢圓形的形狀。

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/XFEllipse

# XFFirst

## 使用 Xamarin.Forms 的專案樣板，建立您第一個 Xamarin.Forms 專案

在這個練習中，只會使用 Xamarin.Forms 的預設專案樣板，建立您第一個 Xamarin.Forms 的專案，並不會在 Xaml / Code Behind / ViewModel 中做任何設計。這個練習的目的，是在於學會如何建立一個 Xamarin.Forms 專案，並且可以成功在不同平台的模擬器下來執行。

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/

# XFFlip

## 使用 CarouselViewControl 來做出有旋轉木馬效果的控制項

這裡有另外一個控制項 CarouselViewControl，非 Xamarin 官方提供的外加控制項，一樣可以做到有旋轉木馬的功能。

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/

# XFFontAwesome

## 如何在 Xamarin.Forms 使用與顯示 Font Awesome

這是一個綜合應用練習在這個練習中，您將會學習到

* 如何將 Font Awesome 字體檔案加入到個原生專案內，並且做出相關設定，讓原生系統可以使用這個字體檔案。

* 建置一個自訂控制項，用來可以顯示 Font Awesome 的字體圖示

* 學習使用 Renderer 技術，改變預設控制項在不同平台顯示的樣貌與內容

* 在 XAML 中指定要顯示 Font Awesome 文字方式

* 練習一個應用程式啟動畫面，進行系統資料讀取與更新的長時間工作，當工作結束後，可以切換到主換面上

* 了解非同步工作的開發與設計方式和注意事項

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/XFFontAwesome

# XFGenBarcode

## 我們可以透過 NuGet 套件，讓應用程式顯示出各種不同條碼的圖片

在這裡，我們學習如何在 XAML 中，使用 ZXingBarcodeImageView 控制項，顯示出一維 / 二維 條碼的圖片在螢幕上；要指定各種不同條碼格式，可以使用 BarcodeFormat 屬性。

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/XFGenBarcode

# XFHListView

## Xamarin.Forms 動態產生檢視項目的 WrapView

使用 FlowListView，顯示出 GridView 這樣效果的控制項，這個控制項相當的實用；這裡將會顯示文字內容

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/XFHListView

# XFHorListView

## 水平捲動的 ListView

在這裡，您需要加入一個命名空間，參考到我們定義的水平式 ListView 客製控制項

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/XFHorListView

# XFImage

## Xamarin.Forms 的 Image 相關使用方式與注意事項

這個範例專案，讓您學習到 Xamarin.Forms 的 Image 相關使用方式與注意事項

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/XFImage

# XFImgZoom

## Xamarin.Forms Behavior 的製作與練習

這個範例將會展示如何將放大等手勢操作功能，把原先需要在 Code Behind 寫的程式碼，包裝到 Xamarin.Forms Behaviors，並且在 XAML中來直接套用

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/XFImgZoom

# XFIValueConverter

## 練習建立一個數值轉換器

在這個練習中，建立一個數值轉換器，接收一個字串文字，根據對應關係，會轉換成為一個顏色物件，若對應不起來，則回傳黑色，若不透過數值轉換器，您可以在 ViewModel 內定義一個 Color 屬性，在 ViewModel 內自行處理這些轉換邏輯

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/XFIValueConverter

# XFLayoutOptions

## 練習各種不同 LayoutOptions 所表現出來的特性

這個專案，將練習 LayoutOptions 的六個列舉值的特性

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/XFLayoutOptions

# XFLifeCycle

## 練習 Xamarin.Forms 的應用程式生命週期

這個專案練習將會練習 Xamarin.Forms 的應用程式生命週期，您需要執行這個專案，觀察 Visual Studio 內的輸出視窗，觀察輸出內容，請試著將應用程式切換為背景模式，並且再度切換成為前景

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/XFLifeCycle

# XFListView

## ListView 的各種不同用法展示

這個範例展示出各種在 ListView 遇到的情境與問題解法

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/XFListView

# XFMoreWrapLayout

## 客製一個 WrapView 控制項，並做到動態收合效果

這裡使用了 WrapView 與 RoundedBoxView 產生出具有折合效果的捲動清單

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/XFMoreWrapLayout

# XFOnPlatform

## 如何在 XAML 與 C# 內，使用 OnPlatform

在這個範例，練習如何使用 OnPlatform 來設定不同平台的XAML控制項有著不同屬性

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/XFOnPlatform

# XFPicker

## 如何使用 Xamarin.Forms 內建的 Picker 控制項

這裡將展示如何使用 Xamarin.Forms 內建的 Picker 控制項，您可以在 Xamarin中，定義靜態的可選擇項目，請使用 x:String 來指定每個紀錄內容

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/XFPicker

# XFPmLM

## Prism 的容器各種使用方式

這個專案將會展示如何使用 Prism 的容器各種使用方式，包含了如何註冊、解析一個要注入的物件與藥注入物件生命週期管理

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/XFPmLM

# XFPrismALM

## 學習 Prism 與 Xamarin.Forms 的頁面事件的執行先後順序之差異

這個專案將會用來測試 Code Behind 的 OnAppearing / OnDisappearing 和 Prism 的 INavigationAware 之 OnNavigatedFro / OnNavigatedTo 事件， 這些事件，在不同情況下、在不同平台下的執行順序，您將會看到不同平台下執行順序差異

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/XFPrismALM

# XFRendCtrl

## 客製專屬平台的控制項視覺

會透過 Xamarin.Forms 提供的相依服務的 ExportRenderer 方法，會將自訂控制項使用每個專屬平台的額外程式碼進行修正，使這些平台上看到的控制項，儘可能一樣。在這裡，也會練習如何使用導航工具列的按鈕製作方式

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/XFRendCtrl

# XFRoundedBoxView

## 展示如何使用可以繪製圓角的控制項與其用法

我們將需要自訂一個控制項，並且在每個平台使用 Renderer 來產生這個具有圓角的矩形

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/XFRoundedBoxView

# XFScan

## 這個專案展示如何進行一維或者二維條碼掃描

不使用 ViewModel ，使用 Code Behind 來展示

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/XFScan

# XFSkiaSharp

## 如何在 Xamarin.Forms 使用類似 Canvas 畫布功能

SKCanvasView 控制項是一個具有畫布功能的控制項，可以讓您在這個控制項上進行各種繪圖動作

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/XFSkiaSharp

# XFTransforms

## 學會如何使用繼承 VisualElement 之任何控制項都會擁有的 變換 Transforms 功能

這個專案將會讓您操作 VisualElement 上的一些轉換行為，例如：平移、縮放、旋轉

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/XFTransforms

# XFTrigger

## 練習 Xamarin.Forms 提供的四種觸發功能 屬性觸發 / 資料觸發 / 事件觸發 / 多重觸發

Trigger 可以讓您在 XAML 中，定義各種不同條件，當條件滿足之後，將會做出各種反應

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/XFTrigger

# XFUserControl

## 如何在 Xamarin.Forms 製作與使用一個使用者控制項 (User Control)

這是一個使用者控制項的練習範例，在這裡，您定義另外一個 XAML 檔案，在這裡宣告一些控制項與版面配置，使其成為一個組合式的控制項，在這裡，不需要繼承任何類別，就可以組合成一個您經常使用的控制項

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/XFUserControl

# XFWrapLayout

## 自己客製一個 WrapView 控制項，並在 Xamarin.Forms 來使用

WrapView 是 Xamarin.Forms 所欠缺的，在這裡將會練習如何使用 WrapView 這個自訂控制項

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/XFWrapLayout

# XFxArray

## 在 ListView 中，直接使用靜態的集合資料，無須透過 ViewModel來指定

如何使用 x:Array 來指定一個靜態資料的 ListView 集合資料來源

https://github.com/vulcanlee/xamarin-forms-develop-notes-example/tree/master/XFxArray

