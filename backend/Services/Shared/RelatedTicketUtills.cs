using Models;
namespace Services.Shared;

public static class RelatedTicketUtills
{
    public static List<Ticket> BuildTicketTree(Ticket currentTicket, List<Ticket> allUserTickets)
    {
        var visitedTickets = new HashSet<Guid>();
        var ticketTree = new List<Ticket>();

        TraverseTree(currentTicket, allUserTickets, ticketTree, visitedTickets);

        return ticketTree;
    }

    private static void TraverseTree(Ticket currentTicket, List<Ticket> allUserTickets, List<Ticket> ticketTree, HashSet<Guid> visitedTickets)
    {
        if (currentTicket == null || visitedTickets.Contains(currentTicket.Id))
            return;

        visitedTickets.Add(currentTicket.Id);
        ticketTree.Add(currentTicket);

        var childTickets = allUserTickets
            .Where(ticket => ticket.RelatedTicketId == currentTicket.Id)
            .ToList();

        foreach (var child in childTickets)
        {
            TraverseTree(child, allUserTickets, ticketTree, visitedTickets);
        }

        var parentTicket = allUserTickets
            .FirstOrDefault(ticket => ticket.Id == currentTicket.RelatedTicketId);

        if (parentTicket != null)
        {
            TraverseTree(parentTicket, allUserTickets, ticketTree, visitedTickets);
        }
    }
}
