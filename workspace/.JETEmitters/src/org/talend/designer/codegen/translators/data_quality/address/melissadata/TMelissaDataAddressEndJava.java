package org.talend.designer.codegen.translators.data_quality.address.melissadata;

import org.talend.core.model.process.INode;
import org.talend.designer.codegen.config.CodeGeneratorArgument;

public class TMelissaDataAddressEndJava
{
  protected static String nl;
  public static synchronized TMelissaDataAddressEndJava create(String lineSeparator)
  {
    nl = lineSeparator;
    TMelissaDataAddressEndJava result = new TMelissaDataAddressEndJava();
    nl = null;
    return result;
  }

  public final String NL = nl == null ? (System.getProperties().getProperty("line.separator")) : nl;
  protected final String TEXT_1 = NL + "ao_";
  protected final String TEXT_2 = ".delete();";
  protected final String TEXT_3 = NL;

  public String generate(Object argument)
  {
    final StringBuffer stringBuffer = new StringBuffer();
    
	CodeGeneratorArgument codeGenArgument = (CodeGeneratorArgument) argument;
	INode node = (INode)codeGenArgument.getArgument();
	String cid = node.getUniqueName();

    stringBuffer.append(TEXT_1);
    stringBuffer.append(cid);
    stringBuffer.append(TEXT_2);
    stringBuffer.append(TEXT_3);
    return stringBuffer.toString();
  }
}
