using System;
using UnityEngine;

/// <summary>
/// Responsable de la gestion de l'état dynamique du jeu.
// Il surveille constamment les événements significatifs tels que les montées de niveau,
// l'ouverture de portes, le déclenchement de dialogues, les changements de tour,
// les pauses et l'expiration des délais, entre autres. Lorsque l'un de ces événements
// se produit, le Game Manager est informé et met à jour l'état actuel du jeu en conséquence.
// De plus, il informe tous les éléments du jeu qui se sont inscrits pour être notifiés
// des changements d'état, assurant ainsi une coordination harmonieuse et réactive de tous
// les aspects du gameplay.
/// </summary>
public class GameManager : Singleton<GameManager>
{
}
