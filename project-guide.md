# Памятка по проекту (Демо-экзамен 09.02.07)

Windows Forms + Entity Framework (Database First, EDMX) + SQL Server.

---

## 1. SQL: первичные ключи

### Создание таблицы с PRIMARY KEY + автоинкрементом

`IDENTITY(seed, increment)` — автогенерация значения: `IDENTITY(1,1)` начинает с 1 и увеличивает на 1.

```sql
CREATE TABLE Category (
    CategoryID  INT IDENTITY(1,1) NOT NULL,
    Name        NVARCHAR(100)     NOT NULL,
    CONSTRAINT PK_Category PRIMARY KEY (CategoryID)
);
```

Короткий inline-вариант (без явного имени constraint — имя сгенерит сервер):

```sql
CREATE TABLE Product (
    ProductID   INT IDENTITY(1,1) PRIMARY KEY,
    Name        NVARCHAR(200)  NOT NULL,
    Price       DECIMAL(10,2)  NOT NULL,
    CategoryID  INT            NULL
);
```

> Именованный constraint (`PK_Category`) лучше: его проще найти, изменить и удалить позже.

### Первичный ключ одной строкой

Когда PK — это одно автоинкрементное поле, всё описание умещается в одну строку прямо в определении столбца:

```sql
UserID INT IDENTITY(1,1) PRIMARY KEY
```

Например, таблица пользователей:

```sql
CREATE TABLE [User] (
    UserID    INT IDENTITY(1,1) PRIMARY KEY,
    Login     NVARCHAR(50)  NOT NULL,
    Password  NVARCHAR(100) NOT NULL,
    RoleID    INT           NOT NULL
);
```

> `User` — зарезервированное слово в T-SQL, поэтому имя таблицы берём в квадратные скобки: `[User]`.

### Добавить PK к уже существующей таблице

```sql
-- столбец сначала должен быть NOT NULL
ALTER TABLE Product ALTER COLUMN ProductID INT NOT NULL;

ALTER TABLE Product
ADD CONSTRAINT PK_Product PRIMARY KEY (ProductID);
```

### Составной первичный ключ

Когда строку уникально определяет комбинация полей (типичный случай — таблица-связка многие-ко-многим):

```sql
CREATE TABLE OrderItem (
    OrderID    INT NOT NULL,
    ProductID  INT NOT NULL,
    Quantity   INT NOT NULL,
    CONSTRAINT PK_OrderItem PRIMARY KEY (OrderID, ProductID)
);
```

### Внешний ключ (FK на PK другой таблицы)

```sql
ALTER TABLE Product
ADD CONSTRAINT FK_Product_Category
FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID);
```

### Удалить PK

```sql
ALTER TABLE Product DROP CONSTRAINT PK_Product;
```

### Почему это важно для EF

EF Database First строит сущности, связи и навигационные свойства **по PK и FK**. Если у таблицы нет первичного ключа, EF сделает её read-only (или не замапит вообще). Правило простое: **у каждой таблицы должен быть PK**, а связи между таблицами — через FK.

---

## 2. Генерация SQL-скрипта средствами SSMS

### Вся база целиком (схема и/или данные)

1. ПКМ по базе → **Tasks** → **Generate Scripts…**
2. **Choose Objects** — вся база или выбранные таблицы.
3. **Set Scripting Options** → кнопка **Advanced**.
4. Параметр **Types of data to script**:
   - `Schema only` — только структура (CREATE TABLE и т.д.);
   - `Data only` — только INSERT-ы с данными;
   - `Schema and data` — структура + данные.
5. Output: в файл, в буфер обмена или в новое окно запроса → **Next** → **Finish**.

### Одна таблица (CREATE-скрипт)

ПКМ по таблице → **Script Table as** → **CREATE To** → **New Query Editor Window**.

### Только данные одной таблицы (INSERT-ы)

Через **Generate Scripts** → выбрать таблицу → Advanced → **Data only**.

> Для сдачи проекта удобно держать в репозитории один полный скрипт `Schema and data`, чтобы базу можно было развернуть с нуля на любой машине.

---

## 3. Сетап проекта с нуля

### Тип проекта

**Windows Forms App (.NET Framework)**, язык C#, версия **4.7.2** или **4.8**.

> Важно: именно **.NET Framework**, а не .NET Core / .NET 5+. Визуальный дизайнер EDMX и EF6 Database First работают только на Framework.

### NuGet-пакеты

Нужен один пакет:

| Пакет | Назначение |
|-------|------------|
| `EntityFramework` (6.x) | ORM, провайдер SQL Server идёт в комплекте |

Установка через **Package Manager Console**:

```powershell
Install-Package EntityFramework
```

Или: ПКМ по проекту → **Manage NuGet Packages** → Browse → `EntityFramework` → Install.

### Добавление Entity-модели (Database First, EDMX)

1. ПКМ по проекту → **Add** → **New Item…**
2. Раздел **Data** → **ADO.NET Entity Data Model** → имя (напр. `AppDbModel`) → **Add**.
3. **EF Designer from database** → **Next**.
4. **New Connection…** → провайдер **Microsoft SQL Server**:
   - Server name: `localhost`, `.\SQLEXPRESS` или имя твоего инстанса;
   - Authentication: Windows / SQL Server;
   - выбрать базу из списка → **OK**.
5. Поставить галочку «**Save connection settings in App.config**», задать имя контекста (напр. `TradeBaseEntities`).
6. Выбрать версию **Entity Framework 6.x**.
7. Отметить нужные **Tables / Views / Stored Procedures** → **Finish**.

Результат: файл `.edmx`, класс `DbContext`, классы сущностей и connection string в `App.config`.

### Использование в коде

```csharp
using (var db = new TradeBaseEntities())
{
    var products = db.Product
        .Where(p => p.Price > 0)
        .OrderBy(p => p.Name)
        .ToList();
}
```

### Если изменилась схема БД

Открыть `.edmx` → ПКМ по пустому месту дизайнера → **Update Model from Database** → вкладки **Add / Refresh / Delete**.
