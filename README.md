# 💾 Save System Tool for Unity

A modular, extensible and editor-friendly Save System for Unity, supporting multiple serialization formats (PlayerPrefs, JSON, XML), with visual debugging and management tools built using Odin Inspector.

---

## ✨ Features

- 🔁 **Strategy Pattern**: Plug-and-play architecture with interchangeable save methods
- 💾 **Supported Formats**:
  - PlayerPrefs (with Odin serialization)
  - JSON file
  - XML file
- 🧠 **Editor Tool**:
  - Odin Editor Window for previewing saved data
  - Visual decoding for PlayerPrefs, JSON, and XML
  - Deletion of individual entries
  - Auto refresh on changes
  - Clear indication of save locations per method
- 🧱 **Extensible Architecture**:
  - Easy to add encryption, cloud saving, or custom file handling
  - Facade over save methods to switch runtime behavior

---

## 📁 File Formats

### 🧠 PlayerPrefs
- Stored in system registry (Windows) or plist (macOS)
- Serialized via Odin using Base64 + JSON

### 📄 JSON
- Located at:
  ```
  Application.persistentDataPath/player_data.json
  ```
- Fully human-readable

### 📂 XML
- Located at:
  ```
  Application.persistentDataPath/player_data.xml
  ```
- Readable and compatible with standard tools

---

## 🛠 Tech Stack
- Unity 2022+
- Odin Inspector
- Sirenix Serialization

---

## 🧪 Example Data Structure

```csharp
[Serializable]
public class PlayerData
{
    public string PlayerName;
    public int Level;
    public float Health;
    public Vector3 Position;
    public bool HasPremium;
    public GameSettings Settings;
    public InventoryData Inventory;
    public QuestProgress[] Quests;
}
```

---

## 📷 Screenshots

> _Coming soon..._

---

## 🧩 Usage

### Save:
```csharp
saveLoadFacade.Save(SaveMethod.Json, playerData);
```

### Load:
```csharp
PlayerData loaded = saveLoadFacade.Load(SaveMethod.PlayerPrefs);
```


---

## 📌 Related Projects
- [Grid Level Editor](https://github.com/SinlessDevil/Grid_Level_Editor)
- [Language Change Tools](https://github.com/SinlessDevil/Language_Change_Tools)
- [Inventory Tetris](https://github.com/SinlessDevil/Inventory_Tetris)

