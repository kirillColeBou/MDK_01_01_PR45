-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Май 09 2024 г., 22:29
-- Версия сервера: 8.0.30
-- Версия PHP: 8.1.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `TaskManager`
--

-- --------------------------------------------------------

--
-- Структура таблицы `Priority`
--

CREATE TABLE `Priority` (
  `Id` int NOT NULL,
  `Name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `Priority`
--

INSERT INTO `Priority` (`Id`, `Name`) VALUES
(1, 'Низкий'),
(2, 'Средний'),
(3, 'Высокий');

-- --------------------------------------------------------

--
-- Структура таблицы `Tasks`
--

CREATE TABLE `Tasks` (
  `Id` int NOT NULL,
  `Name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `PriorityId` int DEFAULT NULL,
  `DateExecute` date DEFAULT NULL,
  `Comment` varchar(1000) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Done` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `Tasks`
--

INSERT INTO `Tasks` (`Id`, `Name`, `PriorityId`, `DateExecute`, `Comment`, `Done`) VALUES
(8, 'asdds', 1, '2024-04-29', 'asd', 0);

-- --------------------------------------------------------

--
-- Структура таблицы `Users`
--

CREATE TABLE `Users` (
  `Id` int NOT NULL,
  `Login` varchar(255) NOT NULL,
  `Password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `Users`
--

INSERT INTO `Users` (`Id`, `Login`, `Password`) VALUES
(1, 'asd', 'asd'),
(3, 'asdd', 'asdd'),
(4, 'asdda', 'asdda'),
(5, 'kirill', '274efe9fab0b00b7c75b551f2f8f0c13');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `Priority`
--
ALTER TABLE `Priority`
  ADD PRIMARY KEY (`Id`);

--
-- Индексы таблицы `Tasks`
--
ALTER TABLE `Tasks`
  ADD PRIMARY KEY (`Id`);

--
-- Индексы таблицы `Users`
--
ALTER TABLE `Users`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `Priority`
--
ALTER TABLE `Priority`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `Tasks`
--
ALTER TABLE `Tasks`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT для таблицы `Users`
--
ALTER TABLE `Users`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
