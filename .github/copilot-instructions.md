# GitHub Copilot Instructions: Useless Filter Mod

## Mod Overview and Purpose

The **Useless Filter** mod is designed to simplify the management of item filters for smelting, burning, deconstructing, and recycling in RimWorld. It introduces two new filters, "useless" and "non-useless," applicable to the Apparel and Weapon lists. These filters allow players to define conditions under which an item is considered useless, thus streamlining the tedious process of filter configuration. Although initially created for personal use, this mod is intended to benefit anyone facing similar filtration challenges.

## Key Features and Systems

- **Filter Types**: Introduces "useless" and "non-useless" filters for Apparel and Weapon lists.
- **Configurable Conditions**: Players can set conditions based on:
  - Percentage of hit points
  - Quality range
  - Whether an item is tainted or clean
  - Whether an item is biocoded or non-biocoded
- **Russian Translation**: The mod includes a Russian translation provided by proselyte223.

## Coding Patterns and Conventions

- **Namespace and Class Organization**: The source files are organized under a common namespace to ensure clean and maintainable code.
- **Class Responsibilities**:
  - `Main.cs`: Contains utility functions, including `IsUseless`.
  - `SpecialThingFilterWorker_*`: Implements the logic for determining if an item matches the "useless" or "non-useless" filter.
  - `UselessFilterMod.cs`: Manages mod settings UI and lifecycle.
  - `UselessFilterSettings.cs`: Handles loading and saving settings.
- **Coding Style**: Follow consistent C# coding conventions such as meaningful variable names, proper use of access modifiers, and XML documentation comments for public members.

## XML Integration

- **XML Defs**: The file `Useless_ThingFilterDef.xml` defines custom `SpecialThingFilterDef` entries to integrate with the game’s data-driven XML system.
- **Translation Support**: Define language translations in XML, facilitating multilingual support, including files in `Source\TranslationTemplate`.

## Harmony Patching

- Use Harmony, a library for patching methods in C#, to extend or modify the game’s existing functionality.
- Ensure patches are applied early in the mod lifecycle. Consider using the `HarmonyPatch` attribute to target specific methods within the game for changes.

## Suggestions for Copilot

To streamline development and maintain consistency, consider the following suggestions when using GitHub Copilot:

- **Commenting**: Ensure code and logic are well-commented. Copilot will generate more relevant code snippets when it understands your intentions.
- **Documentation**: Utilize XML documentation for classes and methods to guide Copilot in generating context-aware code.
- **Pattern Recognition**: Define coding patterns and architectures clearly, so Copilot can recognize and suggest similar patterns elsewhere in the code.
- **Refinement Through Iteration**: Experiment with iteration over Copilot's suggestions; refine them to match your project’s specific needs.
- **Leverage Context**: Use the broader context of your project to help Copilot make more accurate predictions—ensure that relevant parts of the project structure and purpose are clearly defined and documented.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).

