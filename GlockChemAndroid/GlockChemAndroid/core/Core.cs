using System.Collections;
using System.Collections.Generic;

namespace Core {
/** AdvNum - ���������˫��������
 * @author DuckSoft
 * @version 0.1
 */
public class AdvNum {
	// === �ڲ����� ===
	/** AdvNum���ڲ���ֵ��
	 * @see #numInner
	 * @see #numMin
	 * @see #numMax
	 * */
	double numInner;
	/** AdvNum�����ֵ��
	 * @see #numInner
	 * @see #numMin
	 * @see #numMax
	 * */
	double numMax;
	/** AdvNum����Сֵ��
	 * @see #numInner
	 * @see #numMin
	 * @see #numMax
	 * */
	double numMin;
	
	// === ����ת�� ===
	/** ��AdvNum����תΪString
	 * @return ����String
	 */
	public String toString() {
		return "{" + String.valueOf(this.numInner) + 
				"; " + String.valueOf(this.numMin) + 
				", " + String.valueOf(this.numMax) + "}";
	}
	/** ��AdvNum����תΪdouble
	 * @return AdvNum������ڲ���ֵ{@link #numInner}
	 */
	public double toDouble() {
		return this.numInner;
	}
	// === ���캯�� ===
	/** ���캯��
	 * <p>�ù��캯�����Թ���һ���յ�AdvNum��</p>
	 * @see #AdvNum()
	 * @see #AdvNum(double)
	 * @see #AdvNum(double, double)
	 * @see #AdvNum(double, double, double)	 */ 
	public AdvNum() {
		super();
	}
	/** ���캯��
	 * <p>�ù��캯�����Թ���ĳһ˫����ֵ��AdvNum��</p>
	 * @param numIn ����д������AdvNum�е�˫����ֵ
	 * @see #AdvNum()
	 * @see #AdvNum(double)
	 * @see #AdvNum(double, double)
	 * @see #AdvNum(double, double, double)	 */ 
	public AdvNum(double numIn) {
		this.numInner = this.numMax = this.numMin = numIn;
	}
	/** ���캯��
	 * <p>�ù��캯�����Թ�����ĳһ˫������Ϊ���Ĳ�������AdvNum��</p>
	 * @param numCenter ����д���������ֵ
	 * @param numError ��<b>�������ֵ</b>��Ϊ������ֵָ���������ֵ
	 * @see #AdvNum()
	 * @see #AdvNum(double)
	 * @see #AdvNum(double, double)
	 * @see #AdvNum(double, double, double)	 */ 
	public AdvNum(double numCenter, double numError) {
		// ���ֵ����Ϊ�Ǹ���
		assert(numError >= 0);
		
		this.numInner = numCenter;
		this.numMin = numCenter - numError;
		this.numMax = numCenter + numError;
	}
	/** ���캯��
	 * <p>�ù��캯�����԰��û����뷨����AdvNum��</p>
	 * <p><b>ע�����ֵ���Ҫ������Сֵ��</b></p>
	 * @param numCenter ����д���������ֵ
	 * @param numInMin Ϊ������ֵָ������Сֵ
	 * @param numInMax Ϊ������ֵָ�������ֵ
	 * @see #AdvNum()
	 * @see #AdvNum(double)
	 * @see #AdvNum(double, double)
	 * @see #AdvNum(double, double, double)	 */ 
	public AdvNum(double numCenter, double numInMin, double numInMax) {
		// ������ֵ������Сֵ
		assert(numInMin <= numInMax);
		
		this.numInner = numCenter;
		this.numMin = numInMin;
		this.numMax = numInMax;
	}
	
	// === �������㺯�� ===
	public AdvNum add(AdvNum numIn) {
		double numInner = this.numInner + numIn.numInner;
		double numMin = this.numMin + numIn.numMin;
		double numMax = this.numMax + numIn.numMax;
		
		return new AdvNum(numInner, numMin, numMax);
	}
	public AdvNum add(double numIn) {
		return add(new AdvNum(numIn));
	}
	public AdvNum subtract(AdvNum numIn) {
		double numInner = this.numInner - numIn.numInner;
		double numMin = this.numMin - numIn.numMax;
		double numMax = this.numMax - numIn.numMin;
		
		return new AdvNum(numInner, numMin, numMax);
	}
	public AdvNum subtract(double numIn) {
		return subtract(new AdvNum(numIn));
	}
	public AdvNum multiply(AdvNum numIn) {
		double numInner = this.numInner * numIn.numInner;
		double numMin = this.numMin * numIn.numMin;
		double numMax = this.numMax * numIn.numMax;
		
		return new AdvNum(numInner, numMin, numMax);
	}
	public AdvNum multiply(double numIn) {
		return multiply(new AdvNum(numIn));
	}
	public AdvNum divide(AdvNum numIn) {
		double numInner = this.numInner / numIn.numInner;
		double numMin = this.numMin / numIn.numMax;
		double numMax = this.numMax / numIn.numMin;
		
		return new AdvNum(numInner, numMin, numMax);
	}
	public AdvNum divide(double numIn) {
		return divide(new AdvNum(numIn));
	}

	// === �������� ===
	public AdvNum set(double numToSet) {
		this.numInner = this.numMin = this.numMax = numToSet;
		return this;
	}
	
	/** ��ȡAdvNum�����Ļ���
	 * <p>ע��÷�������ȡ���Ļ���������ʹ��AdvNum���Ļ���<br>
	 * ��Ҫ��ĳ��AdvNum���Ļ�����μ�{@link #Centerize()}������</p>
	 * @see #Centerize()
	 * @return ���Ļ����������������ֵ����Сֵ��ƽ����
	 */
	public double getCenterizedNumber() {
		return (this.numMin + this.numMax) / 2;
	}
	
	/** ��AdvNum���Ļ�
	 * <p>����������AdvNum���Ļ�����ʹ���ڲ����ݱ�Ϊ��AdvNum���ֵ����Сֵ��ƽ������<br>
	 * �������ȡĳAdvNum�����Ļ�������μ�{@link #getCenterizedNumber()}������</p>
	 * @see #getCenterizedNumber()
	 * @return ����AdvNum
	 */
	public AdvNum Centerize() {
		this.numInner = this.getCenterizedNumber();
		return this;
	}
	
	public double getNumMin() {
		return this.numMin;
	}
	
	public double getNumMax() {
		return this.numMax;
	}
	
	public double getErrorWidth() {
		return this.numMax - this.numMin;
	}
	
	public double getErrorMin() {
		return this.numInner - this.numMin;
	}
	
	public double getErrorMax() {
		return this.numMax - this.numInner;
	}
}
/** ��ѧ����ʽ����
 * @author DuckSoft
 */
public class Equation {
	/** ��Ӧ���б�*/
	public List<Pair<Formula,Integer>> reactant = new ArrayList<Pair<Formula,Integer>>();
	/** �������б�*/
	public List<Pair<Formula,Integer>> product = new ArrayList<Pair<Formula,Integer>>();
	
	public Equation() {
		
	}
	
	public String toString() {
		String strTemp = new String();
		
		for (Pair<Formula,Integer> pair : reactant) {
			if (pair.getR() != 1) {
				strTemp += String.valueOf(pair.getR());
//				strTemp += " ";
			}
			strTemp += pair.getL().getRawString();
			strTemp += " + ";
		}
		strTemp = strTemp.substring(0, strTemp.length()-3);
		strTemp += " ---> ";
		
		for (Pair<Formula,Integer> pair : product) {
			if (pair.getR() != 1) {
				strTemp += String.valueOf(pair.getR());
//				strTemp += " ";
			}
			strTemp += pair.getL().getRawString();
			strTemp += " + ";
		}
		strTemp = strTemp.substring(0, strTemp.length()-3);
		return strTemp;
	}
	
	
	/** �Ը����ĺ�����Ч��ʽ�Ļ�ѧ����ʽ�ַ�������һ��Equation����<br/>
	 * <p>�ɽ��ܵĸ�ʽʾ�����£�
	 * <li>2C + O2 = 2CO</li>
	 * <li>2C + O2 -> 2CO</li>
	 * <li>2C + O2 === 2CO</li>
	 * <li>2C + O2 ==> 2CO</li>
	 * </p>
	*/
	public Equation(String strEquation) throws Exception {
		this.parseEquation(strEquation);
	}

	/** ��������ʽ
	 * @param strEquation �������ķ���ʽ
	 * @throws Exception
	 */
	public void parseEquation(String strEquation) throws Exception {
		// �����ظ�����
		assert((this.reactant.isEmpty() && this.product.isEmpty()));
		
		// ��������Ϊ��
		if (strEquation.isEmpty()) {
			//TODO: ����Ϊ�յĴ���
			throw new Exception("����Ϊ��");
		}
		
		// �����ظ�����
		
		String partLeft = "";		// ��Ӧ������ﻺ����
		String partRight = "";
		boolean isRight = false;	// �Ƿ����������־ 
		boolean bAuxFlag = false;	// ������־
		
		for (char i : strEquation.toCharArray()) {
			if (i == '=' || i == '-') {	// ���� = �� - ����ʱ�ж�Ϊ��Ӧ����� 
				isRight = true;
				if (bAuxFlag == true) {	// ���ֳ���һ�ηָ��������ж�Ϊ���� 
					throw new Exception("���ֶ���һ���ķ�Ӧ��-������ָ���");
				}
				continue;
			} else if (i == ' ' || i == '>') {	// ���Ե� ---> ��ʽ�е� > �ַ��Լ��հ��ַ�
				continue;
			} else {
				if (isRight == true) {	// ���ѵ��������ﲿ�� 
					bAuxFlag = true; 	// �趨������־ 
				}
			}
			
			if (isRight) {
				partRight += String.valueOf(i);
			} else {
				partLeft += String.valueOf(i);
			}
		}
		
		// ���ڷ��뵽�б���
		if (partLeft.isEmpty() || partRight.isEmpty()) {
			throw new Exception("������ķ�Ӧ���������Ϊ��");
		}

		boolean isStarting = true;	// ��־���Ƿ��ǻ�ѧʽ�Ŀ�ͷ
		String strTempA = "";			// ϵ���洢
		String strTempB = "";			// ��ѧʽ�洢
		
		for (char i : partLeft.toCharArray()) {
			if (isStarting == true) {	// ��Ϊ��ѧʽ�Ŀ�ͷ 
				if (('0' <= i) && (i <= '9')) { // �ж��Ƿ�Ϊ���� 
					strTempA += String.valueOf(i);				// ��Ϊ����ϵ������뵽ϵ���ݴ��� 
				} else {
					isStarting = false;	// �������ʾ���ֲ��ֽ���
					
					if (strTempA.isEmpty()){	// ����û��ϵ������� 
						strTempA = "1";		// ��û��ϵ���������ϵ��"1" 
					}
					
					if (i == '+') {	// ��ֹ��ͷ������"+"�ŵ�������� 
						throw new Exception("�б�ͷ�����հ���");
					} 
					
					strTempB += String.valueOf(i);	// �������ַ����뻯ѧʽ�洢�� 
				}
			} else {	// ���ǻ�ѧʽ�Ŀ�ͷ 
				if (i == '+') {	// ��Ϊ"+"�� 
					if (strTempB.isEmpty() || strTempA.isEmpty()) { // ��ֹ��ѧʽ��ϵ��Ϊ��ʱ�����б�
						throw new Exception("Equation::parseFormulaList: �б��������հ���");
					} else {
						this.reactant.add(new Pair<Formula,Integer>(new Formula(strTempB),new Integer(strTempA)));
						// ��ʼ��״̬ 
						strTempA = "";
						strTempB = "";
						isStarting = true;
					}
				} else {		// ����"+"�� 
					strTempB += String.valueOf(i);	// ֱ�Ӽ��뻯ѧʽ���� 
				}
			}
		}
		
		// ѭ������
		if (!(strTempA.isEmpty() || strTempB.isEmpty())) {
			this.reactant.add(new Pair<Formula,Integer>(new Formula(strTempB),new Integer(strTempA)));
			// ��ʼ��״̬ 
			strTempA = "";
			strTempB = "";
			isStarting = true;
		}
		
		strTempA = "";
		strTempB = "";
		isStarting = true;
		
		for (char i : partRight.toCharArray()) {
			if (isStarting == true) {	// ��Ϊ��ѧʽ�Ŀ�ͷ 
				if (('0' <= i) && (i <= '9')) { // �ж��Ƿ�Ϊ���� 
					strTempA += String.valueOf(i);				// ��Ϊ����ϵ������뵽ϵ���ݴ��� 
				} else {
					isStarting = false;	// �������ʾ���ֲ��ֽ���
					
					if (strTempA.isEmpty()){	// ����û��ϵ������� 
						strTempA = "1";		// ��û��ϵ���������ϵ��"1" 
					}
					
					if (i == '+') {	// ��ֹ��ͷ������"+"�ŵ�������� 
						throw new Exception("�б�ͷ�����հ���");
					} 
					
					strTempB += String.valueOf(i);	// �������ַ����뻯ѧʽ�洢�� 
				}
			} else {	// ���ǻ�ѧʽ�Ŀ�ͷ 
				if (i == '+') {	// ��Ϊ"+"�� 
					if (strTempB.isEmpty() || strTempA.isEmpty()) { // ��ֹ��ѧʽ��ϵ��Ϊ��ʱ�����б�
						throw new Exception("Equation::parseFormulaList: �б��������հ���");
					} else {
						this.product.add(new Pair<Formula,Integer>(new Formula(strTempB),new Integer(strTempA)));
						// ��ʼ��״̬ 
						strTempA = "";
						strTempB = "";
						isStarting = true;
					}
				} else {		// ����"+"�� 
					strTempB += String.valueOf(i);	// ֱ�Ӽ��뻯ѧʽ���� 
				}
			}
		}
		
		// ѭ������
		if (!(strTempA.isEmpty() || strTempB.isEmpty())) {
			this.product.add(new Pair<Formula,Integer>(new Formula(strTempB),new Integer(strTempA)));
			// ��ʼ��״̬ 
			strTempA = "";
			strTempB = "";
			isStarting = true;
		}
	}
}

}