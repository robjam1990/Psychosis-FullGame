using System;
using Newtonsoft.Json;
using System.Numerics;
using System.Drawing;

public static class CollisionDetection
{
    public class Obstacle
    {
        public Vector3 Location { get; set; }
        public Cube BoundingBox { get; set; }

        public Obstacle(Vector3 location, Rectangle boundingBox)
        {
            Location = location;
            BoundingBox = boundingBox;
        }
    }

    public static bool CheckCollision(Entity entity1, Entity entity2)
    {
        var entity1X = ((Vector3)entity1.Location).X;
        var entity1Y = ((Vector3)entity1.Location).Y;
        var entity1Z = ((Vector3)entity1.Location).Z;
        var entity1Width = ((Vector3)entity1.Location).X;
        var entity1Length = entity1.BoundingBox.Y;
        var entity1Height = entity1.BoundingBox.Z;

        var entity2X = ((Vector3)entity2.Location).X;
        var entity2Y = ((Vector3)entity2.Location).Y;
        var entity2Z = ((Vector3)entity2.Location).Z;
        var entity2Width = entity2.BoundingBox.X;
        var entity2Length = entity1.BoundingBox.Y;

        var entity2Height = entity2.BoundingBox.Z;

        if (
                entity1X < entity2X + entity2Width && entity1X + entity1Width > entity2X &&
                entity1Y < entity2Y + entity2Height && entity1Y + entity1Height > entity2Y
            )
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public static bool CheckCollision(Entity entity, Obstacle obstacle)
    {
        var entityX = entity.Location.X;
        var entityY = entity.Location.Y;
        var entityZ = entity.Location.Z;
        var entityWidth = entity.BoundingBox.X;
        var entityLength = entity.BoundingBox.Y;

        var entityHeight = entity.BoundingBox.Z;

        var obstacleX = obstacle.Location.X;
        var obstacleY = obstacle.Location.Y;
        var obstacleZ = obstacle.Location.Z;
        var obstacleWidth = obstacle.BoundingBox.X;
        var obstacleLength = entity.BoundingBox.Y;

        var obstacleHeight = obstacle.BoundingBox.Z;

        if (
                entityX < obstacleX + obstacleWidth && entityX + entityWidth > obstacleX &&
                entityY < obstacleY + obstacleHeight && entityY + entityHeight > obstacleY
            )
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public static bool CheckCollision(Entity entity, Structure structure)
    {
        var entityX = entity.Location.X;
        var entityY = entity.Location.Y;
        var entityZ = entity.Location.Z;
        var entityWidth = entity.BoundingBox.Width;
        var entityLength = entity.BoundingBox.Length;
        var entityHeight = entity.BoundingBox.Height;

        var structureX = structure.Location.X;
        var structureY = structure.Location.Y;
        var structureZ = structure.Location.Z;
        var structureWidth = structure.BoundingBox.Width;
        var structureLength = structure.BoundingBox.Length;
        var structureHeight = structure.BoundingBox.Height;

        if (
                entityX < structureX + structureWidth && entityX + entityWidth > structureX &&
                entityY < structureY + structureHeight && entityY + entityHeight > structureY
            )
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public static bool CheckCollision(Entity entity, Projectile projectile)
    {
        var entityX = entity.Location.X;
        var entityY = entity.Location.Y;
        var entityZ = entity.Location.Z;
        var entityWidth = entity.BoundingBox.Width;
        var entityLength = entity.BoundingBox.Length;
        var entityHeight = entity.BoundingBox.Height;

        var projectileX = projectile.Location.X;
        var projectileY = projectile.Location.Y;
        var projectileZ = projectile.Location.Z;
        var projectileWidth = projectile.BoundingBox.Width;
        var projectileLength = projectile.BoundingBox.Length;
        var projectileHeight = projectile.BoundingBox.Height;

        if (
                entityX < projectileX + projectileWidth && entityX + entityWidth > projectileX &&
                entityY < projectileY + projectileHeight && entityY + entityHeight > projectileY
            )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public class Entity
    {
        internal object? BoundingBox;

        public Vector3 Location { get; internal set; }
    }

    public class Structure
    {
        internal object? BoundingBox;

        public object? Location { get; internal set; }
    }

    public class Projectile
    {
        internal object? BoundingBox;

        public object? Location { get; internal set; }
    }
}
