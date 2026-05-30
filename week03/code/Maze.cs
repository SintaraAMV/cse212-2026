using System;
using System.Collections.Generic;

public class Maze
{
    private Dictionary<(int, int), bool[]> _map;
    private (int x, int y) _currentPosition;

    public Maze(Dictionary<(int, int), bool[]> map)
    {
        _map = map ?? throw new ArgumentNullException(nameof(map));
        _currentPosition = (1, 1); // Posición inicial
    }

    public string GetStatus()
    {
        return $"Current location (x={_currentPosition.x}, y={_currentPosition.y})";
    }

    public void MoveUp()
    {
        TryMove(0, -1, 2); // up está en índice 2
    }

    public void MoveDown()
    {
        TryMove(0, 1, 3); // down está en índice 3
    }

    public void MoveLeft()
    {
        TryMove(-1, 0, 0); // left está en índice 0
    }

    public void MoveRight()
    {
        TryMove(1, 0, 1); // right está en índice 1
    }

    private void TryMove(int dx, int dy, int directionIndex)
    {
        var (currentX, currentY) = _currentPosition;

        // Verificar si la posición actual existe
        if (!_map.ContainsKey((currentX, currentY)))
            throw new InvalidOperationException("Can't go that way!");

        // Obtener direcciones permitidas
        bool[] directions = _map[(currentX, currentY)];

        // Verificar si podemos movernos en esta dirección
        // En el array: [left, right, up, down] - true = se puede mover
        if (directionIndex < 0 || directionIndex >= directions.Length || !directions[directionIndex])
            throw new InvalidOperationException("Can't go that way!");

        // Calcular nueva posición
        int newX = currentX + dx;
        int newY = currentY + dy;

        // Verificar si la nueva posición existe
        if (!_map.ContainsKey((newX, newY)))
            throw new InvalidOperationException("Can't go that way!");

        // Actualizar posición
        _currentPosition = (newX, newY);
    }
}