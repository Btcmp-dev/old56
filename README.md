Настроено было по этому гайду --> https://gist.github.com/geoffalday/c56b94764a64bb44b6d9bc1cc8fffd75
Остальные  
  1. Устанавливают помимо гита Git LFS https://git-lfs.com/
  2. Клопируют репо, в пустую папку (в ней или перед клонированием **git lfs install**, или клонируют через GitHub Desktop)
  3. В Unity Hub - Projects - Add - Add project from disk - Выбирают папку old56 внутри папки склонированного репо
  4. Unity докачивает пакеты, которые указаны в файле проекта и запускает эдитор
  5. ???
  6. Profit


 Unity должна делать это сама, но лучше пытаться отслеживать какие пакеты подгружаем дополнительно для реализации своей технологии - отмечаем в описании коммита
