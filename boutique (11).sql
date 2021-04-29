-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le :  mar. 27 avr. 2021 à 11:23
-- Version du serveur :  10.4.10-MariaDB
-- Version de PHP :  7.3.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `boutique`
--

DELIMITER $$
--
-- Procédures
--
DROP PROCEDURE IF EXISTS `deletePanier`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `deletePanier` (IN `idC` INT)  NO SQL
DELETE FROM panier WHERE panier.idClient = idC$$

DROP PROCEDURE IF EXISTS `delete_article`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `delete_article` (IN `idArt` INT)  BEGIN
DELETE FROM article WHERE article.idArticle = idArt;
DELETE FROM panier WHERE panier.idArticle = idArt;
END$$

DROP PROCEDURE IF EXISTS `getLastCommande`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `getLastCommande` (IN `idC` INT, IN `idPaiement` INT)  NO SQL
SELECT * FROM commande
WHERE commande.idClient = idC
AND commande.idPaiement = idPaiement
ORDER BY commande.idCommande DESC LIMIT 1$$

DROP PROCEDURE IF EXISTS `getLastPaiement`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `getLastPaiement` (IN `var_nom` VARCHAR(100) CHARSET utf8, IN `var_numero_carte` VARCHAR(20) CHARSET utf8, IN `var_date_expiration` VARCHAR(7) CHARSET utf8, IN `var_cvv` VARCHAR(3) CHARSET utf8)  NO SQL
SELECT paiement.idPaiement
FROM paiement
WHERE paiement.nom = var_nom
AND paiement.numero_de_carte = var_numero_carte
AND paiement.date_expiration = var_date_expiration
AND paiement.cvv = var_cvv
ORDER BY paiement.idPaiement DESC
LIMIT 1$$

DROP PROCEDURE IF EXISTS `get_magasin`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `get_magasin` (IN `idC` INT)  NO SQL
SELECT nom, adresse1, adresse2, ville, codePostal, region, telephone FROM magasin WHERE idProprietaire = idC$$

DROP PROCEDURE IF EXISTS `get_panier`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `get_panier` (IN `idC` INT)  NO SQL
SELECT * FROM panier WHERE panier.idClient = idC$$

DROP PROCEDURE IF EXISTS `insertArticlesCommandes`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `insertArticlesCommandes` (IN `var_idCommande` INT, IN `var_idArt` INT, IN `var_idMarchand` INT, IN `var_quantite` INT)  NO SQL
INSERT INTO articlescommandes (articlescommandes.idCommande, articlescommandes.idArticle, articlescommandes.idMarchand, articlescommandes.quantite, articlescommandes.execute)
VALUES (var_idCommande, var_idArt, var_idMarchand, var_quantite, 0)$$

DROP PROCEDURE IF EXISTS `insertCommande`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `insertCommande` (IN `idC` INT, IN `idPaiement` INT)  NO SQL
INSERT INTO commande (commande.idClient, commande.idPaiement)
VALUES (idC, idPaiement)$$

DROP PROCEDURE IF EXISTS `save_adresse1`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `save_adresse1` (IN `string_adresse1` VARCHAR(255) CHARSET utf8, IN `idC` INT)  NO SQL
UPDATE magasin set magasin.adresse1 = string_adresse1 WHERE magasin.idProprietaire = idC$$

DROP PROCEDURE IF EXISTS `save_adresse2`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `save_adresse2` (IN `string_adresse2` VARCHAR(255) CHARSET utf8, IN `idC` INT)  NO SQL
UPDATE magasin SET magasin.adresse2 = string_adresse2 WHERE magasin.idProprietaire = idC$$

DROP PROCEDURE IF EXISTS `save_codePostal`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `save_codePostal` (IN `string_codePostal` VARCHAR(5) CHARSET utf8, IN `idC` INT)  NO SQL
UPDATE magasin SET magasin.codePostal = string_codePostal WHERE magasin.idProprietaire = idC$$

DROP PROCEDURE IF EXISTS `save_magasin_nom`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `save_magasin_nom` (IN `magasin_nom` VARCHAR(100) CHARSET utf8, IN `idC` INT)  NO SQL
UPDATE magasin SET magasin.nom = magasin_nom WHERE magasin.idProprietaire = idC$$

DROP PROCEDURE IF EXISTS `save_region`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `save_region` (IN `string_region` VARCHAR(50) CHARSET utf8, IN `idC` INT)  NO SQL
UPDATE magasin SET magasin.region = string_region WHERE magasin.idProprietaire = idC$$

DROP PROCEDURE IF EXISTS `save_telephone`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `save_telephone` (IN `string_telephone` VARCHAR(12) CHARSET utf8, IN `idC` INT)  NO SQL
UPDATE magasin SET magasin.telephone = string_telephone WHERE magasin.idProprietaire = idC$$

DROP PROCEDURE IF EXISTS `save_ville`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `save_ville` (IN `string_ville` VARCHAR(100) CHARSET utf8, IN `idC` INT)  NO SQL
UPDATE magasin SET magasin.ville = string_ville WHERE magasin.idProprietaire = idC$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Structure de la table `article`
--

DROP TABLE IF EXISTS `article`;
CREATE TABLE IF NOT EXISTS `article` (
  `idArticle` int(11) NOT NULL AUTO_INCREMENT,
  `idCategorie` int(11) NOT NULL,
  `idMagasin` int(10) NOT NULL,
  `nom` varchar(100) NOT NULL,
  `description` text NOT NULL,
  `prix` float NOT NULL,
  `quantite` int(10) NOT NULL,
  `image` text DEFAULT NULL,
  PRIMARY KEY (`idArticle`)
) ENGINE=MyISAM AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `article`
--

INSERT INTO `article` (`idArticle`, `idCategorie`, `idMagasin`, `nom`, `description`, `prix`, `quantite`, `image`) VALUES
(1, 2, 1, 'Hyrule Warriors L\'Ere du Fléau - Nintendo Switch', 'Editeur : Nintendo\n- Genre : Action\n- Public légal : 12+\n- Plateforme - Nintendo Switch\n- Joueur(s) : 1', 49.98, 20, 'https://www.journaldugeek.com/content/uploads/2020/09/packshot-hyrulewarriors-ef-med.jpg'),
(9, 2, 1, 'The Legend of Zelda: Skyward Sword HD Nintendo Switch', 'Plateforme - Nintendo Switch\nGenre - Action\nEditeur - Nintendo\nDate de parution - 16 juillet 2021\nPublic légal - PEGI - 12+', 49.99, 3, 'https://static.fnac-static.com/multimedia/Images/FR/NR/06/8c/aa/11176966/1540-1/tsp20210219111110/The-Legend-of-Zelda-Skyward-Sword-HD-Nintendo-Switch.jpg'),
(10, 2, 1, 'Final Fantasy VII Remake Intergrade PS5', 'Plateforme - PlayStation 5\nGenre - Jeu de rôle/RPG\nEditeur - Square Enix\nDate de parution - 10 juin 2021\nPublic - légal', 60.99, 60, 'https://static.fnac-static.com/multimedia/Images/FR/NR/b8/54/cb/13325496/1540-1/tsp20210302123339/Final-Fantasy-VII-Remake-Intergrade-PS5.jpg'),
(4, 2, 1, 'Cyberpunk 2077 Edition Day One PC\r\n', 'Editeur : CD Prokekt\r\nGenre : Jeu de rôle/RPG\r\nPublic légal : 18+\r\nPlateforme - PC\r\nJoueur(s) : 1', 59.99, 0, 'https://s2.qwant.com/thumbr/150x150/4/3/65b59449dfd92fcfccf839683f371e6568e022134df65773cb74c83b3e35bf/61i41LNbxPL.jpg?u=https%3A%2F%2Fm.media-amazon.com%2Fimages%2FI%2F61i41LNbxPL.jpg&q=0&b=1&p=0&a=0'),
(5, 1, 2, 'Percy Jackson - Le voleur de foudre Tome 1 : Percy Jackson', 'Date de parution : 12/10/2016\r\n- Editeur : Ldp Jeunesse\r\n- Collection : Ldp Jeunesse Series\r\n- Format : 12cm×17cm\r\n- Nombre de page : 480', 7.99, 11, 'https://products-images.di-static.com/image/rick-riordan-percy-jackson-tome-1-le-voleur-de-foudre/9782019109950-475x500-1.jpg'),
(8, 2, 1, 'Animal Crossing : New Horizons pour Nintendo Switch', '- Le jeu propose un tout nouveau système d\'artisanat : collectez des matériaux sur votre île pour tout construire, des meubles jusqu\'aux outils !\n- Détendez-vous en jardinant, en pêchant, en faisant de la décoration ou encore en nouant des relations avec d\'adorables personnages !\n- Jusqu\'à huit joueurs peuvent vivre sur une île; quatre résidents d\'une même île peuvent jouer ensemble simultanément sur une seule console Nintendo switch.\n- Huit joueurs peuvent jouer ensemble sur l\'île de l\'un des joueurs grâce au multijoueur en ligne ou au multijoueur local sans fil !', 44.4, 66, 'https://images-na.ssl-images-amazon.com/images/I/81s8etnYPrL._AC_SL1500_.jpg');

-- --------------------------------------------------------

--
-- Structure de la table `articlescommandes`
--

DROP TABLE IF EXISTS `articlescommandes`;
CREATE TABLE IF NOT EXISTS `articlescommandes` (
  `idArticleCommande` int(11) NOT NULL AUTO_INCREMENT,
  `idCommande` int(11) NOT NULL,
  `idMarchand` int(11) NOT NULL,
  `idArticle` int(11) NOT NULL,
  `quantite` int(11) NOT NULL,
  `execute` tinyint(1) NOT NULL,
  PRIMARY KEY (`idArticleCommande`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `avis`
--

DROP TABLE IF EXISTS `avis`;
CREATE TABLE IF NOT EXISTS `avis` (
  `id_avis` int(11) NOT NULL AUTO_INCREMENT,
  `date` date NOT NULL,
  `id_user` int(11) NOT NULL,
  PRIMARY KEY (`id_avis`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `categorie`
--

DROP TABLE IF EXISTS `categorie`;
CREATE TABLE IF NOT EXISTS `categorie` (
  `idCategorie` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(100) NOT NULL,
  `description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`idCategorie`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `categorie`
--

INSERT INTO `categorie` (`idCategorie`, `nom`, `description`) VALUES
(1, 'Livre', NULL),
(2, 'Jeu vidéo', NULL),
(4, 'Téléphones', NULL);

-- --------------------------------------------------------

--
-- Structure de la table `client`
--

DROP TABLE IF EXISTS `client`;
CREATE TABLE IF NOT EXISTS `client` (
  `idClient` int(11) NOT NULL AUTO_INCREMENT,
  `idRole` int(11) NOT NULL DEFAULT 1,
  `prenom` varchar(100) NOT NULL,
  `nom` varchar(100) NOT NULL,
  `dateNaissance` date NOT NULL,
  `email` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL,
  PRIMARY KEY (`idClient`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `client`
--

INSERT INTO `client` (`idClient`, `idRole`, `prenom`, `nom`, `dateNaissance`, `email`, `password`) VALUES
(6, 2, 'Test', 'Test', '1999-09-27', 'test@test.fr', '$2y$10$xDlT8ysC50pxX1JJwWxePeqJbPSUKmeOKP1bB7/oUnNgHAIZ8jHf2'),
(7, 3, 'Admin', 'Super', '2000-08-16', 'admin@admin.fr', '$2y$10$SkcO9L30eJc5GTiYShmVbuXsoGYy0DmWN8M/445niW8ZTQK.gY6K2');

-- --------------------------------------------------------

--
-- Structure de la table `commande`
--

DROP TABLE IF EXISTS `commande`;
CREATE TABLE IF NOT EXISTS `commande` (
  `idCommande` int(11) NOT NULL AUTO_INCREMENT,
  `idClient` int(11) NOT NULL,
  `idPaiement` int(11) NOT NULL,
  PRIMARY KEY (`idCommande`)
) ENGINE=MyISAM AUTO_INCREMENT=42 DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `listesouhait`
--

DROP TABLE IF EXISTS `listesouhait`;
CREATE TABLE IF NOT EXISTS `listesouhait` (
  `idClient` int(11) NOT NULL,
  `idArticle` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `listesouhait`
--

INSERT INTO `listesouhait` (`idClient`, `idArticle`) VALUES
(6, 10);

-- --------------------------------------------------------

--
-- Structure de la table `magasin`
--

DROP TABLE IF EXISTS `magasin`;
CREATE TABLE IF NOT EXISTS `magasin` (
  `idMagasin` int(11) NOT NULL AUTO_INCREMENT,
  `idProprietaire` int(10) NOT NULL,
  `nom` varchar(255) NOT NULL,
  `adresse1` varchar(255) NOT NULL,
  `adresse2` varchar(255) NOT NULL,
  `ville` varchar(255) NOT NULL,
  `codePostal` varchar(5) NOT NULL,
  `region` varchar(50) NOT NULL,
  `telephone` varchar(10) NOT NULL,
  `photo` text NOT NULL,
  PRIMARY KEY (`idMagasin`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `magasin`
--

INSERT INTO `magasin` (`idMagasin`, `idProprietaire`, `nom`, `adresse1`, `adresse2`, `ville`, `codePostal`, `region`, `telephone`, `photo`) VALUES
(1, 6, 'SuperGaming', '19 Rue Bernard Millet', '', 'Nantes', '44109', 'Pays de la Loire', '0684123498', ''),
(2, 0, 'Bibliolivre', '8 Grande rue', '', 'La Queue-lez-Yvelines', '78940', 'Yvelines', '0677893748', '');

-- --------------------------------------------------------

--
-- Structure de la table `message`
--

DROP TABLE IF EXISTS `message`;
CREATE TABLE IF NOT EXISTS `message` (
  `id_message` int(11) NOT NULL AUTO_INCREMENT,
  `date` datetime NOT NULL,
  `id_client` int(11) NOT NULL,
  `sujet` varchar(255) NOT NULL,
  `contenu` varchar(255) NOT NULL,
  `Lu` tinyint(1) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id_message`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `message`
--

INSERT INTO `message` (`id_message`, `date`, `id_client`, `sujet`, `contenu`, `Lu`) VALUES
(1, '2021-04-12 17:40:09', 6, 'Test', 'Je test les messages', 0);

-- --------------------------------------------------------

--
-- Structure de la table `paiement`
--

DROP TABLE IF EXISTS `paiement`;
CREATE TABLE IF NOT EXISTS `paiement` (
  `idPaiement` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(255) NOT NULL,
  `numero_de_carte` varchar(255) NOT NULL,
  `date_expiration` varchar(255) NOT NULL,
  `cvv` int(3) NOT NULL,
  PRIMARY KEY (`idPaiement`)
) ENGINE=InnoDB AUTO_INCREMENT=65 DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `panier`
--

DROP TABLE IF EXISTS `panier`;
CREATE TABLE IF NOT EXISTS `panier` (
  `idClient` int(11) NOT NULL,
  `idArticle` int(11) NOT NULL,
  `idMagasin` int(11) NOT NULL,
  `quantite` int(11) NOT NULL,
  PRIMARY KEY (`idClient`,`idArticle`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `panier`
--

INSERT INTO `panier` (`idClient`, `idArticle`, `idMagasin`, `quantite`) VALUES
(6, 9, 1, 3);

-- --------------------------------------------------------

--
-- Structure de la table `review`
--

DROP TABLE IF EXISTS `review`;
CREATE TABLE IF NOT EXISTS `review` (
  `contenu` varchar(255) NOT NULL,
  `idArticle` int(11) NOT NULL,
  `pseudo` varchar(100) NOT NULL,
  `dateReview` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `idCommentaire` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`idCommentaire`)
) ENGINE=MyISAM AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `review`
--

INSERT INTO `review` (`contenu`, `idArticle`, `pseudo`, `dateReview`, `idCommentaire`) VALUES
('Bonjour', 5, 'Skylox', '2020-10-20 09:20:38', 6),
('Test', 5, 'Joniec Alexandre', '2020-12-15 17:09:58', 7),
('Les commentaires fonctionnent', 5, 'Joniec Alexandre', '2020-12-15 17:11:38', 8),
('Last', 5, 'Joniec Alexandre', '2020-12-15 17:30:54', 9),
('test', 10, 'Test Test', '2021-04-13 09:34:18', 10);

-- --------------------------------------------------------

--
-- Structure de la table `role`
--

DROP TABLE IF EXISTS `role`;
CREATE TABLE IF NOT EXISTS `role` (
  `id_role` int(11) NOT NULL AUTO_INCREMENT,
  `intitulé` varchar(255) NOT NULL,
  PRIMARY KEY (`id_role`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `role`
--

INSERT INTO `role` (`id_role`, `intitulé`) VALUES
(1, 'Acheteur'),
(2, 'Vendeur'),
(3, 'Admin');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
