# Adaptive Game UI (Agent-Based System)

Adaptive Game UI is an AI-powered system that dynamically customizes game user interfaces based on individual player behavior.
The project focuses on improving usability, accessibility, and overall player experience, especially for players with learning difficulties or attention challenges.

This project was developed as part of an AI Agent Hackathon.

---

## Project Objective
The main objective is to transform static game interfaces into adaptive, intelligent interfaces that respond to how players interact with the game.

Instead of forcing all players to use the same UI layout, the system analyzes player behavior and adjusts the interface dynamically to better suit each player.

---

## Concept Overview
The system monitors player interactions with game UI elements (buttons) and uses an AI agent to analyze usage patterns.

Based on predefined rules, the agent suggests interface improvements such as:
- Resizing buttons
- Repositioning frequently used buttons
- Reducing clutter by hiding less relevant elements

These changes are then applied directly to the game interface.

---

## Data Collection
Player behavior data is collected through:
- Button click frequency (categorized by button type)
- Interaction timing and repetition
- Simple user feedback via a short questionnaire

The collected data is stored in structured files (CSV / JSON) and sent to the AI agent for analysis.

---

## AI Agent Logic
The current system uses a Rule-Based Agent, applying predefined rules such as:

- If a button is clicked fewer than 3 times, increase its size or move it closer
- If a button is frequently used, keep it unchanged
- Ignore system or settings buttons from modification
- Preserve the last valid user preferences 

The agent outputs structured JSON recommendations that are used to update the game interface.

---

## System Architecture
- Unity (Frontend): Game interface and UI rendering
- AI Agent (Backend): Analyzes player interaction data
- n8n Workflow: Acts as a gateway for data transfer and processing
- JSON Communication: Used to apply UI updates dynamically

---

## Live Demo
Play the game directly in your browser:
https://cerine0205.itch.io/betaminds

---

## Demo Video
Watch a short demo explaining the system concept and AI agent behavior:
https://youtu.be/HSmSHbobrww?si=6f0Ci0fRVYmx2nL7

---

## Key Features
- Adaptive and dynamic UI layout
- AI-driven button customization
- Player behavior analysis
- Modular and extensible architecture
- Real-time UI updates (with future optimization)

---

## Current Limitations
- Rule-based logic only (no autonomous learning yet)
- Some UI updates require reloading
- Limited dataset in the current prototype

---

## Future Enhancements
- Upgrade to a Learning Agent (ML-based)
- Real-time UI updates without reloading
- Direct integration between the AI agent and the game engine
- Expand use cases beyond games (e.g., web applications and accessibility tools)
- Broader personalization options for players

---

## Team
- Entesar Alkiyal – Team Lead  
- Cerine Aljahdali – AI Agent Development  
- Ghina Alghaz – Game Development  
- Lana Alghamdi – UI Design  
- Aryam Alruwaitai – Documentation and Reports  

---

## Note
The AI agent is currently disabled in the live demo and operates as a prototype component.
The project focuses on demonstrating the system architecture, agent logic, and adaptive UI concept.

---

## Conclusion
Adaptive Game UI demonstrates how agent-based AI can enhance player experience by transforming static interfaces into intelligent and personalized systems.

The project highlights practical applications of AI agents, user behavior analysis, and human-centered game design.
