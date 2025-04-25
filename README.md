# PrefabCsLib

**PrefabCsLib** is a lightweight C# library that allows you to create and manage prefab-like objects, inspired by Unity's prefab system — but designed specifically for console applications.

It provides a simple workflow to define templates ("prefabs"), register them, and then instantiate multiple copies of them at runtime.

---

## 🧩 Features

- Define reusable, serializable templates for objects
- Modify prefab data using a builder structure before saving
- Instantiate deep clones of your prefabs anytime
- Works exclusively with console apps (no Unity dependency)

---

## 📦 Installation

1. Add the `PrefabCsLib` project to your solution.
2. Reference `PrefabCsLib` from your console application project.

```vbnet
Solution/
│
├── PrefabCsLib/           → Class library with prefab logic
│   ├── IPrefab.cs
│   ├── PrefabBuilder.cs
│   ├── PrefabManager.cs
│   └── README.md          ← You're here!
│
├── Program.cs             ← Your Main program
├── class1.cs
└── class2.cs
```

---

## 🛠 How it Works

### 1. Create your object class implementing `IPrefab`

```csharp
using PrefabCsLib;

// Your custom class representing a prefab
public class Enemy : IPrefab
{
    public string PrefabId { get; private set; }  // Unique ID for this prefab

    public string Name;
    public int Health;
    public float Speed;

    // Constructor used during building and cloning
    public Enemy(string prefabId)
    {
        PrefabId = prefabId;
    }

    // This method is required by IPrefab and returns a copy of the object
    public IPrefab Clone()
    {
        return new Enemy(PrefabId)
        {
            Name = this.Name,
            Health = this.Health,
            Speed = this.Speed
        };
    }

    public override string ToString()
    {
        return $"Enemy: {Name} (HP: {Health}, Speed: {Speed})";
    }
}
```

### 2. Create a prefab using `PrefabBuilder`
```csharp
// Create a builder with an empty Enemy object
var builder = new PrefabBuilder<Enemy>(new Enemy("enemy_orc"));

// Apply values to this instance (temporary object)
builder.ApplyChanges(e =>
{
    e.Name = "Orc";
    e.Health = 120;
    e.Speed = 3.5f;
});

// Save this configured object as a registered prefab
builder.SaveAsPrefab();
```

### 3. Instantiate the prefab multiple times
```csharp
// Instantiate new copies from the registered prefab
var orc1 = (Enemy)PrefabManager.Instantiate("enemy_orc");
var orc2 = (Enemy)PrefabManager.Instantiate("enemy_orc");

// You can now modify them independently
orc1.Name = "Orc A";
orc2.Name = "Orc B";

// Display the result
Console.WriteLine(orc1);  // Output: Enemy: Orc A (HP: 120, Speed: 3.5)
Console.WriteLine(orc2);  // Output: Enemy: Orc B (HP: 120, Speed: 3.5)
```
---
## 👀 Notes
- Your prefab classes must implement IPrefab and provide a Clone() method.

- Only works in console applications.

- This is not a Unity-compatible library. It is meant for pure C# learning, tooling, or simulation projects.

