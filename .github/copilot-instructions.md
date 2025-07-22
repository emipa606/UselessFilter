# Copilot Instructions for RimWorld Modding Project

## Mod Overview and Purpose

This mod, tentatively named "Useless Filter Mod," is designed for RimWorld, a colony management simulation game. The primary purpose of the mod is to enhance the game's item management mechanics by introducing a filtering system that categorizes items as "useless" or "not useless." This allows players to better organize their inventory and streamline their colony's supply chain operations.

## Key Features and Systems

- **Item Categorization**: The mod adds two new filters, "Useless" and "Non-Useless," that can be applied to the in-game storage systems, helping players sort items effectively.
- **User Settings**: Players can customize which items fall under these categories through mod settings.
- **XML Integration**: The mod integrates with RimWorld's XML-based item definitions to dynamically apply filters to a wide variety of in-game items.

## Coding Patterns and Conventions

- **Class Naming**: Classes like `SpecialThingFilterWorker_NonUselessFilter` and `SpecialThingFilterWorker_UselessFilter` indicate that they extend or specialize existing functionality. Classes that are internal to the mod, such as `UselessFilterMod` and `UselessFilterSettings`, follow the internal naming convention to denote their scope.
- **Modularity**: The mod uses clear separations between mod entry point (`UselessFilterMod`), settings (`UselessFilterSettings`), and functional extensions (`SpecialThingFilterWorker_UselessFilter`).
- **C# Conventions**: Follow standard C# naming conventions with PascalCase for classes and methods, and camelCase for local variables.

## XML Integration

- **XML Configuration**: The mod requires XML files to define which items can be classified as "useless" or "non-useless". Ensure that the XML tags are correctly mapped to in-game item definitions.
- **Dynamic Loading**: Use robust XML parsing methods to dynamically load and apply item categories based on XML configuration. The mod should gracefully handle any missing or malformed XML definitions.

## Harmony Patching

- **Method Patching**: Use the Harmony library to patch existing RimWorld methods where necessary. Consider using Harmony Postfix, Prefix, and Transpiler methods to integrate the filter functionality without compromising game stability.
- **Non-Invasive Changes**: Aim for minimal and reversible changes to the original game code to maintain compatibility with other mods.

## Suggestions for Copilot

1. **Code Completion**: Utilize Copilot to write repetitive or boilerplate code, such as standard XML parsing routines or Harmony patch hooks.
2. **Pattern Recognition**: Copilot can assist in identifying common programming patterns within the mod codebase, suggesting optimal refactoring or improvements.
3. **Documentation**: Use Copilot to generate documentation comments for major classes and methods, improving code readability and maintainability.
4. **Error Handling**: Leverage Copilot to suggest robust error handling structures, especially when dealing with external data sources like XML files.
5. **Testing Suggestions**: Ask Copilot to aid in creating unit tests for critical systems within the mod, ensuring the mod works as intended across various scenarios.

By following these instructions, mod developers can make efficient use of GitHub Copilot to enhance their RimWorld mod while maintaining high code quality and game compatibility.
