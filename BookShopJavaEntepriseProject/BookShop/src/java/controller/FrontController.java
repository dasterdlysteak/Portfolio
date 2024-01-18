package controller;

import dispatchers.*;
import javax.servlet.*;
import javax.servlet.http.*;
import java.io.*;
import java.util.*;
//import dispatchers.*;
import model.Book;
import model.CartItem;
import utility.AdmitBookStoreDAO;

/**
 *
 * @author 001175001
 */
public class FrontController extends HttpServlet {

    private final HashMap actions = new HashMap();

    //Initialize global variables

    /**
     *
     * @param config
     * @throws ServletException
     */
    public void init(ServletConfig config) throws ServletException {
        super.init(config);
        actions.put("titles", new TitlesDispatcher());
        actions.put("add_to_cart", new AddToCartDispatcher());
        actions.put("checkout", new CheckoutDispatcher());
        actions.put("continue", new ContinueDispatcher());
        actions.put("home", new HomeDispatcher());
        actions.put("update_cart", new UpdateCartDispatcher());
        actions.put("view_cart", new ViewCartDispatcher());

    }

    //Process the HTTP Get request

    /**
     *
     * @param request
     * @param response
     * @throws ServletException
     * @throws IOException
     */
    public void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        System.err.println("doGet()");
        doPost(request, response);

    }

    //Process the HTTP Post request

    /**
     *
     * @param request
     * @param response
     * @throws ServletException
     * @throws IOException
     */
    public void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
     response.setContentType("text/html");
 //       String next_view = "no view ";
        String requestedAction = request.getParameter("action");
        if (requestedAction == null) {
            requestedAction = "titles";
        }
        IDispatcher dispatcher = (IDispatcher) actions.get(requestedAction);
        String nextPage = dispatcher.execute(request);
        this.dispatch(request, response, nextPage);

    }

    private void dispatch(HttpServletRequest request, HttpServletResponse response, String page) throws ServletException,
            IOException {
        RequestDispatcher dispatcher = getServletContext().getRequestDispatcher(page);
        dispatcher.forward(request, response);
    }

    //Get Servlet information

    /**
     *
     * @return
     */
    public String getServletInfo() {
        return "controller.FrontController Information";
    }

}
