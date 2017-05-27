## Зоопарк

Написать консольное приложение, которое имитирует базовую работу зоопарка. В зоопарке должны жить несколько видов животных: лев, тигр, слон, медведь, волк, лиса. У каждого животного должны быть следующие характеристики: Здоровье (лев - 5 очков, тигр - 4 очка, слон - 7 очков, медведь - 6 очков, волк - 4 очка, лиса - 3 очка) Состояние (Сыт, Голоден, Болен, Мертв) Кличка

Программа должна быть интерактивной и ожидать от пользователя команды:

Добавить животное (после добавления животное имеет Состояние Сыт) - в параметрах передать имя и вид

Покормить животное - в параметрах передать Кличку

Вылечить животное - в параметрах передать Кличку (увеличивает Здоровье на 1, но не больше, чем начальное Здоровье)

Удалить животное из зоопарка (только если животное мертво, иначе ничего не делать)

Вывести пользователю результат каждой команды.

Реализовать механизм, который будет каждый 5 секунд выбирать случайное животное и менять ему состояние в следующем порядке Сыт -> Голоден -> Болен. Если животное было в состоянии Болен, то отнимать одно очко здоровья. Когда Здоровье будет равно 0, перейти в состояние Мертв. Если все животные в зоопарке мертвы, вывести сообщение и завершить программу.

Использовать принципы ООП, практики хорошего кода, оптимальные возможности языка. Желательно использовать паттерны проектирования: фабрика, команда (стратегия), репозиторий.