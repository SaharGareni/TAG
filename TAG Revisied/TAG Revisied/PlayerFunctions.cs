namespace TAG_Revisied
{
    public class PlayerFunctions
    {
        private readonly GameState _gameState;
        public PlayerFunctions(GameState gameState)
        {
            _gameState = gameState;
        }
        public string Take(string itemName)
        {
            if (string.IsNullOrWhiteSpace(itemName))
            {
                return "Take what?";
            }
            if (_gameState.Inventory.Any(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase)))
            {
                return "I already have that.";
            }
            var item = _gameState.RoomManager.CurrentRoom.RoomItems.FirstOrDefault(i => i.Name == itemName);
            if (item != null)
            {
                return item.Take(_gameState);
            }
            item = _gameState.ConditionalItems.FirstOrDefault(i => i.Name == itemName);
            if (item != null)
            {
                return item.Take(_gameState);
            }
            return "I can't take that.";

        }
        public string Inspect(string itemName)
        {

            if (string.IsNullOrWhiteSpace(itemName))
            {
                return _gameState.RoomManager.CurrentRoom.Inspect(_gameState);
            }
            var item = _gameState.GetItem(itemName);
            if (item == null)
            {
                item = _gameState.ConditionalItems.FirstOrDefault(i => i.Name == itemName);
            }
            return item?.Inspect(_gameState) ?? "I can't inspect that.";
        }
        public string Use(string itemName)
        {
            if (string.IsNullOrWhiteSpace(itemName))
            {
                return "Use what?";
            }
            var item = _gameState.GetItem(itemName);
            return item?.Use(_gameState) ?? "I can't use that.";
        }
        public string UseOn(string itemName, string targetName)
        {
            if (string.IsNullOrWhiteSpace(itemName) || string.IsNullOrWhiteSpace(targetName))
            {
                return "Use what?";
            }
            var item = _gameState.GetItem(itemName);
            var targetItem = _gameState.GetItem(targetName);
            return (item != null && targetItem != null) ? item.UseOn(targetItem, _gameState) : "I can't do that.";
        }
        public string Go(string direction)
        {
            if (string.IsNullOrWhiteSpace(direction))
            {
                return "Go where?";
            }
            return _gameState.RoomManager.CurrentRoom.Go(direction,_gameState);
        }
    }
}
