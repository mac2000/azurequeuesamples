Для локальной разработки можно использовать как Azure так и эмулятор

Установка эмулятора через Web Platform Installer - Microsoft Azure SDK for .NET (VS 2015) - 2.8.2.1

Необходимые пакеты для работы с очередью:

- WindowsAzure.Storage
- Microsoft.WindowsAzure.ConfigurationManager - опционально, если хотим заюзать CloudConfigurationManager


https://msdn.microsoft.com/library/zt39148a(v=vs.110).aspx

c:\Windows\Microsoft.NET\Framework\v4.0.30319>InstallUtil.exe


Проблемные моменты:

- "моргание" сети - решается из коробки RetryPolicy
- "транзакции" - нужно думать, решать в зависимости от задачи


Посмотреть в сторону Azure Service Bus - http://geekswithblogs.net/asmith/archive/2012/04/02/149176.aspx