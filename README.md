# Описание
Библиотека классов и клиентское приложение для лабораторных работ по паттернам ООП.
## Модули
### Библиотека MatVec
#### Vectors включает:
* `Vector` на основе массива
* `SparseVector` на основе словаря

Оба предназначены для работы с типом double. 
#### Matrices включает:
* Иерархию `IMatrix`, включающую `Matrix` и `SparseMatrix` на основе обычных и разреженных векторов соответственно
* Иерархию `IDrawer`, включающую `ConsoleDrawer` для отрисовки матриц в консоль и компоновщик `DrawerCompositor`
* Декораторы матриц `TransposeDecorator` и `RenumberDecorator`
* Компоновщики матриц `HCompositorMatrix` и `VCompositorMatrix`
* Иерархии `IImaginators`и `IVisitor` для формирования алгоритма отрисовки матриц
* Вспомогательные классы `MatrixInitializer` и `MatrixStats`
### Клиентское приложение GUIApp
Сделано на основе WinForms. Включает реализации `IDrawer`: `PictureBoxDrawer` и `TextBoxDrawer`, а также три формы:
* `MainForm` позволяет создавать матрицу и отображать её в текстовом и графическом виде, а также перемешивать её элементы
* `MatrixConstructor` используется для создания матриц путём горизонтальной и вертикальной компоновки как самостоятельных, так и составных матриц
* `MatrixParams` вспомогательное окно, позволяющее задать параметры матрицы при её создании
# Пример работы с библиотекой MatVec
Создание матриц и заполнение случайными числами
```C#
IMatrix simple = new Matrix(3, 2);
IMatrix sparse = new SparseMatrix(2, 3);

MatrixInitializer.FillMatrix(simple, 5, 10);
MatrixInitializer.FillMatrix(sparse, 5, 10);
```
Компоновка матриц
```C#
HCompositorMatrix matrix = new HCompositorMatrix();
matrix.Add(simple);
matrix.Add(sparse);
```
Отрисовка объектов
```C#
ConsoleDrawer drawer = new ConsoleDrawer();
MatrixImaginator imaginator = new MatrixImaginator(drawer);
matrix.Draw(imaginator);
```
Вывод в консоли:
```
 ------------------------------
|5,643 1,760 3,974 8,884 5,160 |
|-9,48 4,108 1,647 6,886       |
|-4,52     0                   |
 ------------------------------
```
